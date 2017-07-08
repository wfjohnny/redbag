
    //请求API后台地址
    var Apiurl = "http://localhost:8931/";
    //调用后台链接，json字符串，请求类型：post，get
    function callBackFuncJson(url, jsonVal, type) {
        if (type == "") {
            type = "Post";
        }
        var resdata;
        $.ajax({
            url: Apiurl+url, // url  action是方法的名称
            type: type,
            data: { val: jsonVal },
            async: false,
            xhrFields: {
                withCredentials: true
            },
            crossDomain: true,//新增cookie跨域配置
            dataType: "json",
            contentType: "application/json",
            success: function (data) {
                resdata= data;
            }
        });
        return resdata;
    }
    //调用后台链接，json字符串，请求类型：post，get
    function callBackFunc(url, type) {
        if (type == "")
        {
            type = "Get";
        }
        var resdata;
        $.ajax({
            url:Apiurl+ url, // url  action是方法的名称
            type: type,
            async: false,
            xhrFields: {
                withCredentials: true
            },
            crossDomain: true,//新增cookie跨域配置
            dataType: "json",
            contentType: "application/json",
            success: function (data) {
                resdata= data;
            }
        });
        return resdata;
    }