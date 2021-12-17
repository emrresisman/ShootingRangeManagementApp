$(function () {
    //$(document).ready(function () {
    //    $('#example').DataTable({
    //        dom: 'Bfrtip',
    //        buttons: [
    //            'copy', 'csv', 'excel', 'pdf', 'print'
    //        ]
    //    });
    //});
    $("#example").each(function () {
        
        var dataId = $(this).data('id');

        $(this).DataTable({
            dom: 'Bfrtip',
            buttons: [
                'copy', 'csv', 'excel', 'pdf', 'print'
            ],
           /* dataId eski parametre url in*/
            "ajax": {
                "url": "/Giro/LoadDataDailyGiro/" + $(this).data('id'),
                "type": "POST",
                "datatype": "json"
            },
            "columns": [
                { "data": "id", "name": "storeId", "autoWidth": true },
                { "data": "cash", "name": "Cash", "autoWidth": true },
                { "data": "creditCart", "name": "CreditCard", "autoWidth": true },
                { "data": "date", "name": "Date", "autoWidth": true },
                {
                    "data": "imageName",
                    "render": function (data) {
                        console.log(data);
                        return data == null ? "" : '<img src="/Receipt/' + data + '" class="avatar lightbox" width="50" height="50"/>';
                    }
                },
                { "data": "image", "name": "Image", "autoWidth": true },

                {
                    "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Store/EditDailyStoreGiro/' + full[0] + '">Edit</a>'; }
                },
                {
                    data: null,
                    render: function (data, type, row) {
                        return "<a href='/Store/DeleteDailyStoreGiro' class='btn btn-danger' onclick=DeleteData('" + $(this).data('id') + "'); >Delete</a>";
                    }
                },
            ]

        });
    });

    
});

$(function () {

    $("#datatable2").each(function () {
        var dataId = $(this).data('id');

        $(this).DataTable({

            "ajax": {
                "url": "/Giro/LoadDataDailyBills/" + $(this).data('id'),
                "type": "POST",
                "datatype": "json"
            },
            "columns": [
                { "data": "id", "name": "CustomerID", "autoWidth": true },
                { "data": "date", "name": "Date", "autoWidth": true },
                { "data": "name", "name": "Name", "autoWidth": true },
                { "data": "explanation", "name": "Explanation", "autoWidth": true },
                { "data": "billCost", "name": "BillCost", "autoWidth": true },
               
                {
                    "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Giro/Edit/' + full.Id + '">Edit</a>'; }
                },
                {
                    data: null,
                    render: function (data, type, row) {
                        return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.Id + "'); >Delete</a>";
                    }
                },
            ]

        });
    });

    $('.app-date').datetimepicker({
       
    })

});

//$(function () {

//    $("#datatable2").DataTable({

//        "ajax": {
//            "url": "/Giro/LoadDataDailyBills/" + $(this).data('id'),
//            "type": "POST",
//            "datatype": "json"
//        },
//        "columns": [
//            { "data": "id", "name": "CustomerID", "autoWidth": true },
//            { "data": "date", "name": "Date", "autoWidth": true },
//            { "data": "name", "name": "Name", "autoWidth": true },
//            { "data": "explanation", "name": "Explanation", "autoWidth": true },
//            { "data": "billCost", "name": "BillCost", "autoWidth": true },
//            { "data": "image", "name": "Image", "autoWidth": true },

//            {
//                "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Giro/Edit/' + full.Id + '">Edit</a>'; }
//            },
//            {
//                data: null,
//                render: function (data, type, row) {
//                    return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.Id + "'); >Delete</a>";
//                }
//            },
//        ]

//    });
//});

