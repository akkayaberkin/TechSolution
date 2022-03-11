

$(function () {
    var noteids = [];
    $("table tr").each(function (i, e) {
        var b = $(this).find("td span").data("durum")
        $(this).find("#durumId").val(b);
       
    });
});
$(".TumunuGuncelle").click(function () {
    console.log("test")
});

function TumunuGuncelle() {
    var arr = [];
    var trId = [];
    $("table tr").each(function (i, e) {
        trId.push($(this).attr("id"));
        var a = $(this).find("#durumId").val();
        arr.push(a);
        
    });
    console.log(arr);
    console.log(trId);
   
    $.ajax({
        method: "POST",
        url: "/Kayit/TumunuGuncelleUrunDurum",
        data: { "trId": trId, "arr": arr }
    }).done(function (data) {

        location.reload();

    }).fail(function () {
        alert("Sunucu ile bağlantı kurulamadı.");
    })


}