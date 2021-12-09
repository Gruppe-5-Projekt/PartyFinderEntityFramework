// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function welcome() {
    window.open("/Identity/Account/Register","_self");
}
function loginPage() {
    window.open("/Identity/Account/Login", "_self");
}
function like() {
    var x = document.getElementById("likep");
    if (x.style.display == "none") {
        x.style.display == "block";
    }
}