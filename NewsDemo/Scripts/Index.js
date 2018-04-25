$( document ).ready(function() {
var array = [...];
var newHTML = [];
for (var i = 0; i < array.length; i++) {
    newHTML.push('<span>' + array[i] + '</span>');
}
$(".element").html(newHTML.join(""));
    console.log( "loaded" );
});

var fruits = "/NewsFeed";
document.getElementById("demo").innerHTML = fruits;

function myFunction() {
    fruits.push("Kiwi");
    document.getElementById("demo").innerHTML = fruits;
}