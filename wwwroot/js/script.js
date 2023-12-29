// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.addEventListener("load", () => {
  const urlPath = location.pathname;
  let activeLink = null;
  if (urlPath === "/") {
    activeLink = document.querySelector("#home");
  } else {
    activeLink = document.querySelector("#expense");
  }
  activeLink.classList.add("active");
});
