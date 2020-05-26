$(document).ready(function () {
    $("#txtProductCode").focus();

    $("#txtProductCode").blur(function () {
        var values = $("#txtProductCode").val();
        if (values != undefined && values !== ' ' && values !== "" && values != null) {
            GetProduct(values);
        }
    });

});

function GetProduct(event) {
    alert(event);
    $.ajax({

        url: '/Admin/GetProductByCode',
        type: 'post',
        data: { ProductCode: event },
        success: function (data) {

            $("#txtProductCode").val(data.ProductCode);
            $("#ItemName").val(data.ItemName);
            $("#Price").val(data.Price);
        },
        error: function (error) {
            alet("Failed");
        }
    });
}

