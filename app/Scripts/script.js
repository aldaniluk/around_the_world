//$(function(){
//    var m = new Masonry($('.countries').get()[0], {
//        itemSelector: ".countries__country"
//    });
//});

//var container = document.querySelector('.countries');
//var msnry;
//// ������������� �������, ����� �������� �����������
//imagesLoaded(container, function () {
//    msnry = new Masonry(container);
//});

//var $container = $('#container');
//// ������������� �������, ����� �������� �����������
//$container.imagesLoaded(function () {
//    $container.masonry();
//});

//jQuery(document).ready(function($) {
//    $('.countries').masonry({
//        itemSelector: '.countries__country'
//    });
//});

jQuery(document).ready(function () {
    var $grid = $('.countries');
    $grid.imagesLoaded(function () {
         //init Masonry after all images have loaded
        $grid.masonry({
            itemSelector: '.countries__country'
        });
    });
});