//<div class="dropdown-list">
//<select style="display: none;">
//<option value="value-1">Option 1</option>
//<option value="value-2">Option 2</option>
//<option value="value-3">Option 3</option>
//<option value="value-4">Option 4</option>
//<option value="value-5">Option 5</option>
//</select>
//<div class="current" data-value="">Option 1</div>
//<div class="options-container" style="position: absolute; display: none;">
//<div class="dropdown-item" data-value="value-1" data-index="0">Option1</div>
//<div class="dropdown-item" data-value="value-2" data-index="1">Option 2</div>
//<div class="dropdown-item" data-value="value-3" data-index="2">Option 3</div>
//<div class="dropdown-item" data-value="value-4" data-index="3">Option 4</div>
//<div class="dropdown-item" data-value="value-5" data-index="4">Option 5</div>
//</div>
//</div>

function solve() {
    return function (selector) {
        var div = $('<div />').attr('class', 'dropdown-list');

        var select = $(selector).css('display', 'none');
        div.append(select);

        $('body').append(div);

        var text = $(select).children().first('option').text();
        //console.log(text);
        if(text == ''){
            text = 'no options'
        }
        var currentDiv = $('<div />').attr({
            'class':'current',
            'data-value':''
        }).text(text);

        div.append(currentDiv);
        var optionsContainer = $('<div />').attr('class', 'options-container').css({
            'position':'absolute',
            'display':'none'
        });

        div.append(optionsContainer);

        var len =select.children('option').size();

        var options = select.children('option');
        for(var i=0; i<len; i+=1){
            var divToAdd = $('<div />').attr({
                'class':'dropdown-item',
                'data-value':$(options[i]).attr('value'),
                'data-index':i+1
            }).text($(options[i]).text())

            optionsContainer.append(divToAdd)
        }

        $(optionsContainer).on('click', '.dropdown-item', function(ev){
            var target = ev.target;
            $(currentDiv).attr('data-value', $(target).attr('data-value')).text($(target).text())
            $(select).children('option').removeAttr('selected');
            $('select option[value='+$(target).attr('data-value')+']').attr("selected", "selected");
            $(optionsContainer).hide()

        });

        $(currentDiv).on('click',function(){
           $(optionsContainer).toggle('display')
            var $this = $(this);
            $this.text('Select an option');
        })
    };
}

module.exports = solve;