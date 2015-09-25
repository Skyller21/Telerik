function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        // Wrap the input
        var divWrapper = $('<div />').addClass('datepicker-wrapper');
        divWrapper.insertBefore(this);
        this.appendTo(divWrapper);

        var div = $('<div />');
        div.addClass('picker');
        $(div).hide();
        var date = Date.now();

        var date1 = new Date(date);

        var month = date1.getMonthName();
        var year = date1.getYear() + 1900;


        var divControls = $('<div />');
        divControls.addClass('controls');


        div.append(divControls)
        var divMonth = $('<div />');
        divMonth.text(month + ' ' + year);

        var leftControl = $('<div />').text('<');
        var rightControl = $('<div />').text('>');
        leftControl.addClass('btn')
        rightControl.addClass('btn')
        leftControl.css('display', 'inline-block')
        rightControl.css('display', 'inline-block')

        divMonth.addClass('current-month');

        divMonth.append(leftControl);
        divMonth.append(rightControl);


        var divDate = $('<div />');
        divDate.addClass('current-date');

        var dateLink = $('<a />').addClass('current-date-link');
        dateLink.text(date1.getDay() + ' ' + month + ' ' + year);
        divDate.append(dateLink);




        divControls.append(leftControl);
        divControls.append(divMonth);
        divControls.append(rightControl);

        div.append(divControls)

        function daysInMonth(month, year) {
            return new Date(year, month, 0).getDate();
        }


        var month1 = MONTH_NAMES.indexOf(month);

        var monthDays = daysInMonth(month1, year);

        var dateToCheckDay = new Date(month + ' 1, ' + year);


        //console.log(monthDays);


        var table = $('<table />');

        table.addClass('calendar');

        for (var i = 0; i < 6; i++) {
            var tr = $('<tr />')

            for (var j = 0; j < 7; j++) {

                var td = $('<td />');
                if (i == 0) {
                    td.text(WEEK_DAY_NAMES[j]);
                }

                tr.append(td);
            }
            table.append(tr);
        }


        div.append(table)
        div.append(divDate)
        divWrapper.append(div);

        this.on('click', function () {
            $(div).show();
        })



        $('.current-date-link').on('click', function(){
          var $target = $(this);

            //console.log($target.text());

            var newDate = new Date($target.text())
            $('#date').val(newDate.getDay()+'/'+(newDate.getMonth()+1)+'/'+(newDate.getYear()+1900));

            $('.picker').hide();


        })
        //// you are welcome :)
        //var date = new Date();
        //console.log(date.getDayName());
        //console.log(date.getMonthName());
    };
}

module.exports = solve;