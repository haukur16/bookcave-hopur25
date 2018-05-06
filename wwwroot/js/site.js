// Write your JavaScript code.
// Get the modal
var modal = document.getElementById('id01');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

function empty() {
    var x;
    x = document.getElementById("layoutsearch").value;
    if (x == "") {
        alert("Search bar empty");
        return false;
    };
}