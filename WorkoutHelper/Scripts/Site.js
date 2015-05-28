$(document).ready(function () {

});


//AutoComplete
$("#exerciseInput").autocomplete({
	minLength: 0,
	source: function (request, response) {
		//request= current value. response: suggested data
		$.ajax({
			url: "@Url.Action("ExerciseAutocomplete", "ExerciseProgram")",
			dataType: "json",
		data: { query: request.term },
		success: function (data) {
			response($.map(data, function (item) {
				return {
					label: item.Value,
					id: item.Key
				};
			}));
		}
	});
},
select: function (event, ui) {
	$("#exerciseInput").val(ui.item.label);
	$("#exerciseId").val(ui.item.id);
	//ui.item.value = ui.item.label;
},
change: function (event, ui) {
	if (!ui.item) {
		$("#exerciseInput").val("");
	}
}
});
$("#exerciseInput").focus(function () {
	$(this).autocomplete("search", $(this).val());
})

//var selectedDate;
//$(function () {
//	$("#datepicker").datepicker({
//		dateFormat: "yy-mm-dd",
//		altField: "#selectedDateField",
//		altFormat: "DD, d MM, yy",
//		onSelect: function (date) {
//			//GetAvailableTables(DateTime date, int size)
//			var id = $("#").attr("value");
//			var action = $("#getAvailableTablesAction").attr("value");
//			var ppl = $("#NumberOfPeople").attr("value");
//			var tables = $.getJSON(action + "?id=" + id + "&date=" + date + "&size=" + ppl, function (data) {

//			});
//		},
//	});
//});

//$(function () {
//	$("#dateButton").on("click", function () {
//		var ppl = $("#NumberOfPeople").attr("value");

//	});
//});

