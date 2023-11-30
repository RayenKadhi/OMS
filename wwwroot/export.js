window.exportToExcel = function (data) {
    // Get the current timestamp
    var now = new Date();
    var day = String(now.getDate()).padStart(2, '0');
    var month = String(now.getMonth() + 1).padStart(2, '0');
    var year = now.getFullYear();
    var hours = String(now.getHours() % 12 || 12).padStart(2, '0');
    var minutes = String(now.getMinutes()).padStart(2, '0');
    var seconds = String(now.getSeconds()).padStart(2, '0');
    var period = now.getHours() < 12 ? 'AM' : 'PM';

    var timestamp = `products_${day}_${month}_${year}_${hours}_${minutes}_${seconds}_${period}`;

    // Call your API endpoint to download the Excel file
    fetch('/download', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => response.blob())
        .then(blob => {
            // Create a temporary link and trigger a click to start the download
            var url = window.URL.createObjectURL(blob);
            var a = document.createElement('a');
            // Include the timestamp in the file name with slashes
            a.download = timestamp + '.xlsx';
            a.href = url;
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
            window.URL.revokeObjectURL(url);
        });
}