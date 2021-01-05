$(document).ready(function () {
    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')        
    });

    var boardGamesNames = $('.gameName').map(function () {
        return $(this).text();
    }).get();
    var matchesNumber = $('.matchesNumber').map(function () {
        return $(this).text();
    }).get();

    var options = {
        chart: {
            type: 'bar'
        },
        series: [{
            name: 'Matches played',
            data: matchesNumber,
        }],
        xaxis: {
            name: 'Name of game',
            categories: boardGamesNames,
        }
    }

    var chart = new ApexCharts(document.querySelector("#chart"), options);

    chart.render();

    $('#dataTable').DataTable();
    
})

function searchResult() {

    var rowsName = $('.gameName');
    var input = $('#searchBox').val();

    for (var i = 0; i < rowsName.length; i++) {
        var cell = $('.gameName').get(i).innerText.toString();
        cell = cell.substr(0, input.length).toLowerCase();
        if (input.toLowerCase() === cell) {
            $(".rowResult").get(i).setAttribute("style", "display:table-row");
            
        }
        else {
            $(".rowResult").get(i).setAttribute("style", "display:none");
        }
    }
}