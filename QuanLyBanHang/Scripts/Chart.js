google.charts.load('current', { 'packages': ['corechart'] });

google.charts.setOnLoadCallback(drawChart);

function drawChart() {

    // Create the data table.
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Topping');
    data.addColumn('number', 'Slices');
    var json = JSON.parse(this.ViewBag.Result.Content);
    var StatusDone = 0;
    var StatusUnDone = 0;
    $.each(json, function (k, v) {
        if (v.Status == 1)
            StatusDone++;
        else
            StatusUnDone++;
    });
    data.addRows([
        ['Đã hoàn thành', StatusDone],
        ['Chưa xử lý', StatusUnDone]
    ]);

    var options = {};

    var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
    chart.draw(data, options);
}