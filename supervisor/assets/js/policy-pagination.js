//the .children('a') below can be replaced with .children('tag or class name of the result items')
function paginateit(content) {
   
    var show_per_page = 5; //change this to the amount you want to see for each set
    
    var number_of_items = $(content).children('.listData').size();
   
    var number_of_pages = Math.ceil(number_of_items / show_per_page);
   
    if (number_of_items > show_per_page) {

        $(content).parent().find('.current_page').val(0);
        $(content).parent().find('.show_per_page').val(show_per_page);
        load_navigation(0, content);
        //$(content).parent().find('#page_navigation .page-item:first').addClass('activePagination');
        //$(content).parent().find('#page_navigation .previous_link').addClass('previous_link disablelink');
        $(content).children('.listData').css('display', 'none');      
        $(content).children('.listData').slice(0, show_per_page).css('display', 'block');            
        $(content).find('#' + show_per_page).css('display', 'block');

       
    }
}
function load_navigation(page_num, content) {

    var number_of_items = $(content).children('.listData').size();
    
    var show_per_page = $(content).parent().find('.show_per_page').val();
    
    var number_of_pages = Math.ceil(number_of_items / show_per_page);
 
    var navigation_html;
   
    if (page_num === 0) {
       
        navigation_html = ' ';
    }
    else {
        navigation_html = ' ';
    }
    var max_pages_to_show = 3;
    if (number_of_pages > max_pages_to_show) {
        var middle_items = 2;
        var current_page = $(content).parent().find('.current_page').val();
        var start_range = parseInt(current_page) - Math.floor(middle_items);
        var end_range = parseInt(current_page) + Math.floor(middle_items);
        if (start_range < 0) {
            end_range += Math.abs(start_range);
            start_range = 0;
        }
        if (end_range > number_of_pages) {
            start_range -= end_range - number_of_pages;
            end_range = number_of_pages;
        }
        var i = 0;
        while (i <= number_of_pages - 1) {
            if (start_range > 2 && i === start_range) {
                navigation_html += '...';
            }
            if (i === 1 || i === number_of_pages - 1 || (i >= start_range && i <= end_range)) {
                if (i < page_num)
                    navigation_html += '<div class="page-item mx-1"><a class="page-link prevButton" href="javascript:go_to_page(' + i + ',\'' + content + '\')" longdesc="' + i + '"></a></div>';
                else
                    navigation_html += '<div class="page-item mx-1"><a class="page-link nextButton" href="javascript:go_to_page(' + i + ',\'' + content + '\')" longdesc="' + i + '"></a></div>';
            }
            if (end_range < number_of_pages - 1 && i === end_range) {
                navigation_html += '...';
            }
            i++;
        }
    } else {
        var current_link = 0;
        while (number_of_pages > current_link) {
            if (page_num < current_link)
                navigation_html += '<div class="page-item mx-1"><a class="page-link nextButton" href="javascript:go_to_page(' + current_link + ',\'' + content + '\')" longdesc="' + current_link + '"></a></div>';
            else
                navigation_html += '<div class="page-item mx-1"><a class="page-link prevButton" href="javascript:go_to_page(' + current_link + ',\'' + content + '\')" longdesc="' + current_link + '"></a></div>';
            current_link++;
        }
    }
    // alert(number_of_pages);
    //if (number_of_pages == 3) {
    //navigation_html += '<a class="next_link disablelink" href="javascript:next_Page(\'' + content + '\');">Next</a>';
    //}
    //if (page_num === number_of_pages - 1) {

    //    navigation_html += '<div class="page-item mx-1"><a class="page-link pagination-next">></a></li>';
    //}
    //else {
    //    navigation_html += '<div class="page-item mx-1"><a class="page-link pagination-next" href="javascript:next_Page(\'' + content + '\');"></a></li>';
    //}
    
    $(content).parent().find('#page_navigation').html(navigation_html);
    $('.page-link[longdesc=' + page_num + ']').parent('div').addClass('activePagination').siblings('.activePagination').removeClass('activePagination');
    $('.page-link[longdesc=' + page_num + ']').parent('div').find('a').addClass('activePagination').siblings('.activePagination').removeClass('activePagination');
}

function previous(content) {
    new_page = parseInt($(content).parent().find('.current_page').val()) - 1;
    //if there is an item before the current active link run the function
    if ($(content).parent().find('.activePagination').prev('.page-item').length === 1) {
        go_to_page(new_page, content);
    }
}
function next_Page(content) {
    new_page = parseInt($(content).parent().find('.current_page').val()) + 1;
    //if there is an item after the current active link run the function
   
    if ($(content).parent().find('.activePagination').next('.page-item').length === 1) {
        go_to_page(new_page, content);
    }
}
function go_to_page(page_num, content) {
    $('html, body').animate({ scrollTop: $(content).offset().top - 200 }, 'slow');

    var show_per_page = parseInt($(content).parent().find('.show_per_page').val());
    start_from = page_num * show_per_page;
    end_on = start_from + show_per_page;
    $(content).children('.listData').css('display', 'none').slice(start_from, end_on).css('display', 'block');
    $(content).parent().find('.current_page').val(page_num);
    load_navigation(page_num, content);
   

   
}