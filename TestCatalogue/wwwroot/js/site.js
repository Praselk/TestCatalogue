// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#inpFirstName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: './api/employees/search',
                headers: {                    
                },
                data: { "term": request.term },
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (xhr, textStatus, error) {
                    alert(xhr.statusText);
                },
                failure: function (response) {
                    alert("failure " + response.responseText);
                }
            });
        },
        select: function (e, i) {
            $("#hfCustomer").text(i.item.value);
        },
        minLength: 2
    });
});