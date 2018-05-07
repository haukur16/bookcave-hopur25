// Write your JavaScript code.
function empty() {
    var x;
    x = document.getElementById("layoutsearch").value;
    if (x == "") {
        alert("Search bar empty");
        return false;
    };
}

$(function () {
    $(".index-books").slice(0, 8).show();
    $("#moreBooksButton").on('click', function (e) {
        e.preventDefault();
        $(".index-books:hidden").slice(0, 8).slideDown();
        if ($(".index-books:hidden").length == 0) {
            $("#moreBooksButton").fadeOut('slow');
        }
        $('html,body').animate({
            scrollTop: $(this).offset().top
        }, 1500);
    });
});