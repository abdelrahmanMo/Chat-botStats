const drawPie = (maleCount, femaleCount) => {

    var data = [
        {
            label: "Male",
            data: maleCount,
            color: "#d3d3d3"
        }, {
            label: "Female",
            data: femaleCount,
            color: "#1ab394"
        }
    ];

    var plotObj = $.plot($("#flot-pie-chart"),
        data,
        {
            series: {
                pie: {
                    show: true
                }
            },
            grid: {
                hoverable: true
            },
            tooltip: true,
            tooltipOpts: {
                content: "%p.0%, %s", // show percentages, rounding to 2 decimal places
                shifts: {
                    x: 20,
                    y: 0
                },
                defaultTheme: false
            }
        });

};