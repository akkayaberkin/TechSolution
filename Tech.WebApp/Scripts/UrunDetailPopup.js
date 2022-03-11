

$(function () {
    $('#urun_detay').on('show.bs.modal', function (e) {

        var btn = $(e.relatedTarget);
        urunid = btn.data("urun-id");

        $("#urun_detay_body").load("/Kayit/UrunDetayGetir/" + urunid);
    });
});
   