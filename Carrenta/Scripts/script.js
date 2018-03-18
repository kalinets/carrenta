$(document).ready(function () {

  // homepage slider
  if ($(".homepage__slider")) {
    $(".homepage__slider").slick({
      autoplay: true
    });
  }

  //$("#datestart").datepicker({
  //  startDate: "today",
  //  autoclose: true,
  //  weekStart: 1,
  //  format: 'mm/dd/yyyy',
  //  daysOfWeekHighlighted: [0, 6]
  //});
  //$("#dateend").datepicker({
  //  startDate: "today",
  //  autoclose: true,
  //  weekStart: 1,
  //  format: 'mm/dd/yyyy',
  //  daysOfWeekHighlighted: [0, 6]
  //});

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
      var startDate = $(this).val();
      console.log($(this).val());
      console.log(typeof $(this).val());
      document.getElementById("dateend").setAttribute("min", startDate);
    });

});
