const _ajax = (url, objs, isBlockUi, callback) => {
    isBlockUi = _isNull(isBlockUi) ? true : isBlockUi;
    $.ajax({
        type: _Config.AjaxType.Post,
        async: true,
        cache: false,
        url: url,
        dataType: "json",
        //traditional: true,
        //contentType: 'application/json',
        data: objs,
        success(res) {
            if (callback) {

                if (isBlockUi) {
                    _UnBlockUI();
                }

                callback(res);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            SessionExpired(xhr);
        },
        beforeSend() {
            if (isBlockUi) {
                _BlockUI();
            }
        },
        complete() {
            if (isBlockUi) {
                _UnBlockUI();
            }
        }
    });
}