﻿$(function () {

    var noteids = [];

    $("div[data-note-id]").each(function (i, e) {
        noteids.push($(e).data("note-id"));
    });

    $.ajax({
        method: "POST",
        url: "/Kayit/GetLiked",
        data: { ids: noteids }
    }).done(function (data) {

        if (data.result != null && data.result.length > 0) {
            for (var i = 0; i < data.result.length; i++) {
                var id = data.result[i];
                var likedNote = $("button[data-note-id=" + id + "]");
                //var btn = likedNote.find("button[data-liked]");
                var span = likedNote.find("span.like-star");
                likedNote.data("liked", true);
                span.removeClass("fa-regular fa-star");
                span.addClass("fa-solid fa-star");
            }

        }

    }).fail(function () {

    });



    $("button[data-liked]").click(function () {
        var btn = $(this);
        var liked = btn.data("liked");
        var noteid = btn.data("note-id");
        var spanStar = btn.find("span.like-star");
        var spanCount = btn.find("span.like-count");

        console.log(liked);
        console.log("like count : " + spanCount.text());

        $.ajax({
            method: "POST",
            url: "/Kayit/SetLikeState",
            data: { "noteid": noteid, "liked": !liked }
        }).done(function (data) {

            console.log(data);

            if (data.hasError) {
                alert(data.errorMessage);
            } else {
                liked = !liked;
                btn.data("liked", liked);
                spanCount.text(data.result);

                console.log("like count(after) : " + spanCount.text());


                spanStar.removeClass("fa-solid fa-star");
                spanStar.removeClass("fa-regular fa-star");
                

                if (liked) {
                    spanStar.addClass("fa-solid fa-star");
                } else {
                    spanStar.addClass("fa-regular fa-star");
                }

            }

        }).fail(function () {
            alert("Sunucu ile bağlantı kurulamadı.");
        })

    });
});