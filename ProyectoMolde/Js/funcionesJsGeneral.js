﻿function getDate(fechaString)
{
    return new Date(parseInt(fechaString.replace('/Date(', '').replace(')/', '')));
}

function getDateString(fechaString)
{
    fecha = new Date(parseInt(fechaString.replace('/Date(', '').replace(')/', '')));

    var day = fecha.getDate();
    var month = fecha.getMonth() + 1;
    var year = fecha.getFullYear();

    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    return today = year + "-" + month + "-" + day;
}