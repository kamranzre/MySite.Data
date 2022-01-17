
var form = $('#form');
form.submit(function (event) {
    event.preventDefault();
    $.ajax({
        url: $(this).attr('action'),
        type: $(this).attr("method"),
        dataType: "JSON",
        data: new FormData(this),
        processData: false,
        contentType: false,
       
    }).done(function (data) {
        if (data) {
            $("#Name").val('');
            $("#FName").val('');
            $("#NationalCode").val('');
            $("#PhoneNumber").val('');
            refreshGrid("#grid_Person");
            ShowAlertToast(0, "کاربر با موفقیت ثبت شد");
        } else {
            ShowAlertToast(1, "خطا در انجام عملیات");

        }

       
    });
});








