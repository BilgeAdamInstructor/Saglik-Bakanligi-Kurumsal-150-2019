var util = {
    getToken: function () {
        $.ajax({
            type: 'POST',
            url: 'http://test-jwt.hazir.net/users/authenticate',
            data: '{username:"test", password:"123456"}',
            contentType: 'application/json',
            success: function (resultData) {
                console.log(resultData.token);
                window.Token = resultData.token;
                $("#Token").val(resultData.token);
            },
            error: function (resultData) {
                console.log(resultData);
            }
        });
    },
    getValues: function () {
        $.ajax({
            type: 'GET',
            url: 'http://test-jwt.hazir.net/users',

            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + window.Token);// values alanına ulaşırken token ı eklemiş oldukç.
            },
            data: {},
            success: function (data) {
                //$.each(data, function (i) {
                //    console.log(data[i]);
                //})

                //for (var i = 0; i < data.length; i++) {
                //    util.postValues(data[i]);
                //}
                obj = data;

                util.postValues();
            },

            error: function (data) {
                console.log(data);
            }
        });
    },
    postValues: function () {
        console.log(obj);
        $.ajax({
            type: 'POST',
            url: 'http://localhost:53748/api/users',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + window.Token);// values alanına ulaşırken token ı eklemiş oldukç.
            },
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify(obj),
            success: function (data) {
                console.log(data);
            },
            error: function (data) {
                console.log(data);
            }
        });
    },
}