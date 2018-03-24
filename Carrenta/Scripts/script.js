$(document).ready(function () {

  // homepage slider
  if ($(".homepage__slider")) {
    $(".homepage__slider").slick({
      autoplay: true,
      adaptiveHeight: true
  });
  }

  $(".delete-user").on("click", function (event) {
    event.preventDefault();
    $(this).parents("tr").remove();
  });

  // table sort
  $(".table").DataTable({
    paging: false,
    info: false
  });


  $("#datestart").on("change",
    function () {
      $("#dateend").val("");
      var startDate = $(this).val();
      document.getElementById("dateend").setAttribute("min", startDate);
    });

});
