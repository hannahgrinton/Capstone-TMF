// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//changes the file name displayed to user when image is selected to be uploaded
$("#imgFile").change(function() {
    console.log($(this).val());
    var filename = $(this).val().split("\\").pop();
    $("#message").text(filename);
});
//does the math for the user - updates field for amount due
$("#cost").keyup(function() {
    var cost = parseFloat($(this).val());
    if ($("#paid").val() != null || $("#paid").val() != 0) {
        var paid = parseFloat($("#paid").val());
        var due = cost - paid;
        $("#due").val(due);
    } else {
        $("#due").val(cost);
    }
});
$("#paid").keyup(function() {
    var cost = parseFloat($("#cost").val());
    var paid = parseFloat($("#paid").val());
    var due = cost - paid;
    $("#due").val(due);
});


var menuHidden = true;

$(".filter-menu-toggle").click(function() {

        $("#filter-menu").toggle();
    }

);