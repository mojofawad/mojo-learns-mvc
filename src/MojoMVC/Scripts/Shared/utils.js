function convertUtcToLocal() {
    $('.utc-date').each(function () {
        var utcDateStr = $(this).text();
        if (utcDateStr) {
            if (!utcDateStr.endsWith('Z')) {
                utcDateStr += 'Z';
            }

            var localDate = new Date(utcDateStr);

            if (!isNaN(localDate.getTime())) {
                var formattedDate = localDate.toLocaleString();
                $(this).text(formattedDate);
            }
        }
    });
}

function completeAjaxSuccess() {
    convertUtcToLocal();
};$(document).ready(function () {
    convertUtcToLocal();
});