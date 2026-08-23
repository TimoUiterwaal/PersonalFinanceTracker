// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('click', function (e) {
    const row = e.target.closest('tr.clickable-row');
    if (!row || e.target.closest('a, button')) return;
    window.location = row.dataset.href;
});