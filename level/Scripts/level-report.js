$().ready(function () {
    initChart();
    initAutocomplete();
});



var reportChart;


function initChart() {
    var ctx = document.getElementById('chartReport').getContext('2d');
    reportChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Monday', 'Thuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'],
            datasets: [{
                label: '# of Votes',
                data: [0, 0, 0, 0, 0, 0, 0],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)',
                    'rgba(153, 102, 255, 1)',
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

function initAutocomplete() {
    $('#autocmplete-category').autocomplete({
        serviceUrl: '/Statistic/Suggestion',
        onSelect: function (suggestion) {
            updateChartData(suggestion.data);
        }
    });
}


function updateChartData(suggestionData) {
    $.get("/Statistic/Chart", { categoryId: suggestionData }, function (data) {
        redrawChart(data);
    });
}


function redrawChart(chartData) {
    let options = { weekday: 'long' };
    var chartLabels = [];
    for (var i = 0; i < 7; i++) {
        let date = new Date(Date.now());
        date.setDate(date.getDate() - 6 + i);
        chartLabels[i] = new Intl.DateTimeFormat('en-US', options).format(date);
    }

    reportChart.data.labels = chartLabels;
    reportChart.data.datasets[0].data = chartData;
    reportChart.update();
}
