//Ajax data islemleri
var Ajax = {
    Post: function (url, data, successEvent, showLoading) {
        try {
            showLoading = (typeof showLoading == 'undefined' || showLoading == null) ? true : Boolean(showLoading);
            $.ajax({
                type: "POST",
                url: url,
                data: data,
                cache: false,
                dataType: "json",
                success: function (result) {
                    if (result != null && result.HasError != null && result.HasError == true) {
                        alert(result.Messages);
                        return;
                    };
                    successEvent(result);
                },
                error: function (result) {
                }
            });
        } catch (e) {
        };
    },
    JsonPost: function (url, data, successEvent, showLoading) {
        try {
            showLoading = (typeof showLoading == 'undefined' || showLoading == null) ? true : Boolean(showLoading);
            $.ajax({
                type: "POST",
                url: url,
                data: JSON.stringify(data),
                cache: false,
                contentType: "application/json",
                dataType: "json",
                beforeSend: function () {
                    if (showLoading) Metronic.blockUI({ boxed: true });
                },
                success: function (result) {
                    if (result != null && result.HasError != null && result.HasError == true) {
                        ShowAlertList(result.Messages);
                        return;
                    };
                    successEvent(result);
                },
                error: function (result) {

                },
                complete: function () {
                }
            });
        } catch (e) {
        };
    },
    Get: function (url, data, successEvent, showLoading) {
        try {
            showLoading = (typeof showLoading == 'undefined' || showLoading == null) ? true : Boolean(showLoading);
            $.ajax({
                type: "GET",
                url: url,
                data: data,
                cache: false,
                dataType: "json",
                success: function (result) {
                    if (result != null && result.HasError != null && result.HasError == true) {
                        ShowAlertList(result.Messages);
                        return;
                    };
                    successEvent(result);
                },
                error: function (result) {
                }
            });
        } catch (e) {

        };
    },
    JsonGet: function (url, data, successEvent, showLoading) {
        try {
            showLoading = (typeof showLoading == 'undefined' || showLoading == null) ? true : Boolean(showLoading);
            $.ajax({
                type: "GET",
                url: url,
                data: JSON.stringify(data),
                cache: false,
                contentType: "application/json",
                dataType: "json",
                beforeSend: function () {
                    if (showLoading) Metronic.blockUI({ boxed: true });
                },
                success: function (result) {
                    if (result != null && result.HasError != null && result.HasError == true) {
                        ShowAlertList(result.Messages);
                        return;
                    };
                    successEvent(result);
                },
                error: function (result) {

                },
                complete: function () {
                }
            });
        } catch (e) {

        };
    },
    HtmlLoad: function (url, data, htmlContainerId, successEvent, showLoading) {
        try {
            showLoading = (typeof showLoading == 'undefined' || showLoading == null) ? true : Boolean(showLoading);
            $.ajax({
                type: "GET",
                cache: false,
                url: url,
                data: data,
                dataType: "html",
                beforeSend: function () {
                    if (showLoading) Metronic.blockUI({ boxed: true });
                },
                success: function (result) {
                    if (result != null && result.HasError != null && result.HasError == true) {
                        ShowAlertList(result.Messages);
                        return;
                    };
                    $('#' + htmlContainerId).empty().append(result);
                    try {
                        GlobalPageLoad();
                    } catch (e) {
                        console.log(e.message);
                    }
                    successEvent();
                },
                error: function (xhr, ajaxOptions, thrownError) {

                },
                complete: function () {
                }
            });
        } catch (e) {
        };
    }
};
