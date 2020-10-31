function _login(IsAuthenWin, isLoginA400, authUrl, authAs400Url) {
    $('#form-login').find(".username").focus();

    $('#btnLogin').click(function (e) {
        e.preventDefault();
        let $scope = $('#form-login');
        if (isvalidate($scope)) {
            var l = Ladda.create(this);
            l.start();
            $scope.find('#msg').text(null);
            _ajax(authUrl, {
                UserName: $scope.find('.username').val(),
                Password: $scope.find('.password').val()
            }, false, function (res) {
                if (res.Success) {
                    l.stop();
                    if (isLoginA400) {
                        $('#modalAction').modal('show');
                    } else {
                        $(location).attr('href', res.Datas);
                    }
                } else {
                    l.stop();
                    $('#msg').text(res.Message);
                }
            });
        }
    });

    $('#btnLogin-as400').click(function (e) {
        e.preventDefault();
        let $scope = $('#form-login-as400');
        if (isvalidate($scope)) {
            var ll = Ladda.create(this);
            ll.start();
            $scope.find('#msg').text(null);
            _ajax(authAs400Url, {
                UserName: $scope.find('.username').val(),
                Password: $scope.find('.password').val()
            }, false, function (res) {
                if (res.Success) {
                    $(location).attr('href', res.Datas);

                } else {
                    ll.stop();
                    $scope.find('#msg').text(res.Message);
                }
            });
        }
    });

    const isvalidate = ($scope) => {
        let message = '';
        let $username = $scope.find('.username');
        let $password = $scope.find('.password');
        let $msg = $scope.find('#msg');

        if (_isNull($username.val())) {
            $username.parent().addClass('has-error');
            message = 'กรุณากรอก UserName';
        } else {
            $username.parent().removeClass('has-error');
        }

        if (_isNull($password.val())) {
            $password.parent().addClass('has-error');
            message = _isNull(message) ? 'กรุณากรอก Password' : `${message} และ Pwssword`;
        } else {
            $password.parent().removeClass('has-error');
        }

        if (_isNull(message)) {
            $msg.text(null);
            return true;
        } else {
            $msg.text(message);
            return false;
        }
    }

    $("#modalAction").on('show.bs.modal', () => {
        setTimeout(() => { $('#form-login-as400 .username').focus(); }, 500);
    });

    if (IsAuthenWin && isLoginA400) {
        $('#btnLogin').click();
    }
}