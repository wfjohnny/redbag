$(function () {
    // 声明一个代理引用该集线器,记得$.connection.后面的方法首字母必须要小写,这也是我为什么使用别名的原因
    //var chat = $.connection.chatHub;
    //debugger
    //// 这里是注册集线器调用的方法,和1.0不同的是需要chat.client后注册,1.0则不需要
    //chat.client.broadcastMessage = function (name) {
    //    var bag = "<p class=\"am-text-center cf f12\">09:24</p>";
    //    bag += " <li><div class=\"oz\">";
    //    bag += "   <div class=\"right\">";
    //    bag += "<a href=\"\"><img src=\"../Jscript/hongbao/images/touxiang.jpg\" /></a>";
    //    bag += "</div>";
    //    bag += "<div class=\"cont_right\">";
    //    bag += "<a class=\"cf\" href=\"\">";
    //    bag += "<div>恭喜发财,大吉大利 </div>";
    //    bag += "领取金蛋";
    //    bag += "</a>";
    //    bag += "</div>";
    //    bag += "</div> </li>";
    //    parent.$("#msg").append(bag);
    //};
    ////// 获取用户名称。
    ////$('#username').html(prompt('请输入您的名称:', ''));
    ////// 设置初始焦点到消息输入框。
    ////$('#message').focus();

    //// 启动连接,这里和1.0也有区别
    //$.connection.hub.start().done(function () {
       
    //});
     $("#sendBeans").click(function () {
            debugger
            // 这里是调用服务器的方法,同样,首字母小写
            var remark = $("#remark").val();
            if (remark == null) {
                remark = "恭喜发财，大吉大利";
            }
            parent.chat.server.sendBean($(".zongjine").val(), $(".hongbaogeshu").val(), remark).done(function () {
                parent.layer.closeAll("iframe");
            });
        });
    $("#close").click(function () {
        parent.layer.closeAll("iframe");
    });
    $(".zongjine").change(function (a,input) {
        $("#num").html($(".zongjine").val());
    });
});