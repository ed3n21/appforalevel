$().ready(function () {
    renderChart();
    initAutocomplete();

    $('.report-btn').click(getTrafficData);
});

function renderChart() {

    var ctx = document.getElementById('chartReport').getContext('2d');
    var chartReport = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
            datasets: [{
                label: '# of Votes',
                data: [12, 19, 3, 5, 2, 3],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
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

    $('#autocomplete-report').autocomplete({
        
        serviceUrl: '/Statistic/AutoCompleteSuggestion',
        onSelect: function (suggestion) {
            //alert('You selected: ' + suggestion.value + ', ' + suggestion.data);
        }, 

    });
}


function getTrafficData() {
    var categoryName = $('#autocomplete-report').val();

    $.ajax({
        url: "/api/Report/GetTrafficData/",
        type: 'GET',
        data: { "category": categoryName },
        success: function (result) {
            // TODO update traffic data
            console.log(result);
        },
        error: function(error)
        {
            
            if (error.status == 404) {
                alert(error.responseText);
            }

            console.log(error);
        }
    });
}
