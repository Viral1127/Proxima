(function ($) {
  'use strict';
    if ($("#visit-sale-chart").length) {

        $(document).ready(function () {
            if ($("#visit-sale-chart").length) {
                $.ajax({
                    url: "https://localhost:7107/api/AdminDashboard/GetAdminDashboardData",
                    type: "GET",
                    dataType: "json",
                    success: function (response) {
                        let months = [];
                        let totalProjects = [];

                        // Extract ProjectsPerMonth data
                        response.projectsPerMonth.forEach(item => {
                            months.push(item.monthName); // Labels (Month names)
                            totalProjects.push(item.totalProjects); // Data (Total projects per month)
                        });

                        renderChart(months, totalProjects);
                    },
                    error: function (error) {
                        console.log("Error fetching dashboard data:", error);
                    }
                });
            }
        });

        function renderChart(months, totalProjects) {
            const ctx = document.getElementById('visit-sale-chart').getContext("2d");

            var gradientStrokeViolet = ctx.createLinearGradient(0, 0, 0, 181);
            gradientStrokeViolet.addColorStop(0, 'rgba(218, 140, 255, 1)');
            gradientStrokeViolet.addColorStop(1, 'rgba(154, 85, 255, 1)');
            var gradientLegendViolet = 'linear-gradient(to right, rgba(218, 140, 255, 1), rgba(154, 85, 255, 1))';

            const bgColor1 = ["rgba(218, 140, 255, 1)"];
            

            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: months, // Dynamic Month Labels
                    datasets: [{
                        label: "Total Projects",
                        borderColor: gradientStrokeViolet,
                        backgroundColor: gradientStrokeViolet,
                        fillColor: bgColor1,
                        hoverBackgroundColor: gradientStrokeViolet,
                        pointRadius: 0,
                        fill: false,
                        borderWidth: 1,
                        fill: 'origin',
                        data: totalProjects,
                        barPercentage: 0.5,
                        categoryPercentage: 0.5,
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: true,
                    elements: {
                        line: {
                            tension: 0.4,
                        },
                    },
                    scales: {
                        y: {
                            display: false,
                            grid: {
                                display: true,
                                drawOnChartArea: true,
                                drawTicks: false,
                            },
                        },
                        x: {
                            display: true,
                            grid: {
                                display: false,
                            },
                        }
                    },
                    plugins: {
                        legend: {
                            display: false,
                        }
                    }
                },
            });
        }
  }

    if ($("#traffic-chart").length) {
        $.ajax({
            url: 'https://localhost:7107/api/AdminDashboard/GetAdminDashboardData', // Replace with your actual API endpoint
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                const projectStatusCounts = data.projectStatusCounts;

                // Extract labels and data dynamically from API response
                const labels = projectStatusCounts.map(item => `${item.status} (${item.totalProjects})`);
                const values = projectStatusCounts.map(item => item.totalProjects);

                const ctx = document.getElementById('traffic-chart');

                var graphGradient1 = ctx.getContext('2d');
                var graphGradient2 = ctx.getContext('2d');
                var graphGradient3 = ctx.getContext('2d');

                var gradientStrokeBlue = graphGradient1.createLinearGradient(0, 0, 0, 181);
                gradientStrokeBlue.addColorStop(0, 'rgba(54, 215, 232, 1)');
                gradientStrokeBlue.addColorStop(1, 'rgba(177, 148, 250, 1)');
                var gradientLegendBlue = 'rgba(54, 215, 232, 1)';

                var gradientStrokeRed = graphGradient2.createLinearGradient(0, 0, 0, 50);
                gradientStrokeRed.addColorStop(0, 'rgba(255, 191, 150, 1)');
                gradientStrokeRed.addColorStop(1, 'rgba(254, 112, 150, 1)');
                var gradientLegendRed = 'rgba(254, 112, 150, 1)';

                var gradientStrokeGreen = graphGradient3.createLinearGradient(0, 0, 0, 300);
                gradientStrokeGreen.addColorStop(0, 'rgba(6, 185, 157, 1)');
                gradientStrokeGreen.addColorStop(1, 'rgba(132, 217, 210, 1)');
                var gradientLegendGreen = 'rgba(6, 185, 157, 1)';

                var backgroundColors = [gradientStrokeBlue, gradientStrokeGreen, gradientStrokeRed];
                var legendColors = [gradientLegendBlue, gradientLegendGreen, gradientLegendRed];

                new Chart(ctx, {
                    type: 'doughnut',
                    data: {
                        labels: labels,
                        datasets: [{
                            data: values,
                            backgroundColor: backgroundColors,
                            hoverBackgroundColor: backgroundColors,
                            borderColor: backgroundColors,
                            legendColor: legendColors
                        }]
                    },
                    options: {
                        cutout: 50,
                        animationEasing: "easeOutBounce",
                        animateRotate: true,
                        animateScale: false,
                        responsive: true,
                        maintainAspectRatio: true,
                        showScale: true,
                        legend: false,
                        plugins: {
                            legend: {
                                display: false,
                            }
                        }
                    },
                    plugins: [{
                        afterDatasetUpdate: function (chart, args, options) {
                            const chartId = chart.canvas.id;
                            const legendId = `${chartId}-legend`;
                            const ul = document.createElement('ul');

                            chart.data.labels.forEach((label, i) => {
                                ul.innerHTML += `
                <li>
                  <span style="background-color: ${chart.data.datasets[0].legendColor[i]}"></span>
                  ${label}
                </li>
              `;
                            });

                            document.getElementById(legendId).innerHTML = "";
                            document.getElementById(legendId).appendChild(ul);
                        }
                    }]
                });
            },
            error: function (xhr, status, error) {
                console.error("Error fetching project status data:", error);
            }
        });
    }




  if ($("#inline-datepicker").length) {
    $('#inline-datepicker').datepicker({
      enableOnReadonly: true,
      todayHighlight: true,
    });
  }
  if ($.cookie('purple-pro-banner') != "true") {
    document.querySelector('#proBanner').classList.add('d-flex');
    document.querySelector('.navbar').classList.remove('fixed-top');
  } else {
    document.querySelector('#proBanner').classList.add('d-none');
    document.querySelector('.navbar').classList.add('fixed-top');
  }

  if ($(".navbar").hasClass("fixed-top")) {
    document.querySelector('.page-body-wrapper').classList.remove('pt-0');
    document.querySelector('.navbar').classList.remove('pt-5');
  } else {
    document.querySelector('.page-body-wrapper').classList.add('pt-0');
    document.querySelector('.navbar').classList.add('pt-5');
    document.querySelector('.navbar').classList.add('mt-3');

  }
  document.querySelector('#bannerClose').addEventListener('click', function () {
    document.querySelector('#proBanner').classList.add('d-none');
    document.querySelector('#proBanner').classList.remove('d-flex');
    document.querySelector('.navbar').classList.remove('pt-5');
    document.querySelector('.navbar').classList.add('fixed-top');
    document.querySelector('.page-body-wrapper').classList.add('proBanner-padding-top');
    document.querySelector('.navbar').classList.remove('mt-3');
    var date = new Date();
    date.setTime(date.getTime() + 24 * 60 * 60 * 1000);
    $.cookie('purple-pro-banner', "true", {
      expires: date
    });
  });
})(jQuery);