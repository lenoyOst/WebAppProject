﻿// set the dimensions and margins of the graph
var width = 450
height = 450
margin = 40

// The radius of the pieplot is half the width or half the height (smallest one). I subtract a bit of margin.
var radius = Math.min(width, height) / 2 - margin

// append the svg object to the div called 'my_dataviz'
var svg = d3.select("#my_dataviz")
    .append("svg")
    .attr("width", width)
    .attr("height", height)
    .append("g")
    .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");

// set data

var data = { Male: document.getElementById('Male').attributes.getNamedItem("value").nodeValue, Female: document.getElementById('Female').attributes.getNamedItem("value").nodeValue, Other: document.getElementById('Other').attributes.getNamedItem("value").nodeValue }

// set the color scale
var color = d3.scaleOrdinal()
    .domain(data)
    .range(["#98abc5", "#8a89a6", "#7b6888", "#6b486b", "#a05d56"])

// Compute the position of each group on the pie:
var pie = d3.pie()
    .value(function (d) { return d.value; })
var data_ready = pie(d3.entries(data))

// Build the pie chart: Basically, each part of the pie is a path that we build using the arc function.
svg
    .selectAll('whatever')
    .data(data_ready)
    .enter()
    .append('path')
    .attr('d', d3.arc()
        .innerRadius(0)
        .outerRadius(radius)
    )
    .attr('fill', function (d) { return (color(d.data.key)) })
    .attr("stroke", "black")
    .style("stroke-width", "2px")
    .style("opacity", 0.7)
// Get the angle on the arc and then rotate by -90 degrees
var getAngle = function (d) {
    return (180 / Math.PI * (d.startAngle + d.endAngle) / 2 - 90);
};
svg
    .selectAll('mySlices')
    .data(data_ready)
    .enter()
    .append('text')
    .text(function (d) { return d.data.key})
    .attr("transform", function (d) {
        return "translate(" + pos.centroid(d) + ") " +
            "rotate(" + getAngle(d) + ")";
    }).attr("dy", 5) 
    .style("text-anchor", "start")
    .style("font-size", 17)




