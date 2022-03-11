$(function () {

    $(".nav-item").click(function () {
        var btn = $(this);
        var liked = btn.data("liked");
        var noteid = btn.data("note-id");
        var spanStar = btn.find("span.like-star");
        var spanCount = btn.find("span.like-count");



    });
    $("#searchBox").change( function () {

        let q = $(this).val();
        //console.log(q);
        window.location.href = "/Home/Index?q=" + q;
    });
})