// Write your JavaScript code.
function empty() {
    var x;
    x = document.getElementById("layoutsearch").value;
    if (x == "") {
        alert("Search bar empty");
        return false;
    };
}
/*
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
});*/

$( document ).ready(function () {
    $(".index-books").slice(0, 8).css("display","inline-block");
      if ($(".index-books:hidden").length != 0) {
        $("#moreBooksButton").show();
      }   
      $("#moreBooksButton").on('click', function (e) {
        e.preventDefault();
        $(".index-books:hidden").slice(0, 8).slideDown().css("display","inline-block");
        if ($(".index-books:hidden").length == 0) {
          $("#moreBooksButton").fadeOut('slow');
        }
      });
    });

    $('.reviews #BookReview').keyup(function() {
    
        var characterCount = $(this).val().length,
            current = $('#current'),
            maximum = $('#maximum'),
            theCount = $('#the-count');
          
        current.text(characterCount);

        if (characterCount < 50) {
            current.css('color', '#000');
            current.css('font-weight', 'normal');
        }

        if (characterCount > 50) {
            current.css('color', '#ee7600');
            current.css('font-weight', 'normal');
        }
        if (characterCount > 60 && characterCount < 70) {
            current.css('color', '#841c1c');
            current.css('font-weight', 'normal');
        }
        if (characterCount == 70) {
            maximum.css('color', '#8f0001');
            current.css('color', '#8f0001');
            theCount.css('font-weight','bold');
        } 
        else {
            maximum.css('color','#000');
            theCount.css('font-weight','normal');
        }
              
    });
