

var Util = {
    Helpers: {
        Ajax: function (type, url, data, beforeSendMethod, successMethod, errorMethod) {

            $.ajax({
                type: type,
                url: url,
                contentType: "application/json",
                data: JSON.stringify(data),
                beforeSend: function (xhr) {
                    if (beforeSendMethod) beforeSendMethod(xhr);
                },
                success: function (data) {
                    if (successMethod) successMethod(data);
                },
                error: function (err) {
                    if (errorMethod) errorMethod(err);
                }
            })
        },
        ErrorMethod(err) {
            console.log(err);
        },
        Table: {
            AddRow: function (tableName, colArray) {
                var tr = document.createElement('tr');
                var tbl = document.getElementById(tableName);
                if (tbl) {
                    for (var i = 0; i < colArray.length; i++) Util.Helpers.Table.AddCol(tr, colArray[i]);
                    tbl.appendChild(tr);
                }
            },
            AddCol: function (tr, val) {
                var td = document.createElement('td');
                td.innerHTML = val;
                tr.appendChild(td);
            },
            ClearTableRow: function (tableName) {
                var tbl = document.getElementById(tableName);
                if (tbl) {
                    var count = tbl.rows.length;
                    for (var i = 0; i < count; i++) tbl.deleteRow(0);
                }
            }
        }
    },
    Users: {
        Token: '',
        ApiAddress:'http://localhost:5000/api/users/',
        CreateToken: function (username, password) {
            var data = { username, password };
            var url = 'http://test-jwt.hazir.net/users/authenticate';
            Util.Helpers.Ajax('POST', url, data, null, Util.Users.CallbackMethods.CreateTokenSuccess);
        },
        GetAll: function () {
            var url = 'http://test-jwt.hazir.net/users';
            Util.Helpers.Ajax('GET', url, null, Util.Users.SetToken, Util.Users.CallbackMethods.GetAllSuccess, Util.Helpers.ErrorMethod);
        },
        SetToken: function (xhr) {
            console.log(Util.Users.Token);
            xhr.setRequestHeader('Authorization', 'Bearer ' + Util.Users.Token);
        },
        ShowAll: function () {
            var url = Util.Users.ApiAddress + 'getall';
            Util.Helpers.Ajax('GET', url, null, null, Util.Users.CallbackMethods.ShowAllSuccess, Util.Helpers.ErrorMethod)
        },
        CallbackMethods: {
            CreateTokenSuccess: function (result) {
                console.log(result);
                Util.Users.Token = result.token;
            },
            GetAllSuccess: function (result) {
                console.log(result);
                var data = {
                    users: result
                };
                console.log(data);
                var url = Util.Users.ApiAddress + 'save';
                Util.Helpers.Ajax('POST', url, data);
            },
            ShowAllSuccess: function (data) {
                if (data) {
                    Util.Helpers.Table.ClearTableRow('usersTable');
                    Util.Helpers.Table.AddRow('usersTable', ['', 'First Name', 'Last Name','User Name']);
                    for (var i = 0; i < data.length; i++) {
                        Util.Helpers.Table.AddRow('usersTable', [data[i].id, data[i].firstName, data[i].lastName, data[i].userName]);
                    }
                }
            }
        }
    }
}