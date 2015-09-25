var cookiesController = function() {

  function all(context) {

    var cookies;
    var category = this.params.category || '';
    category = category.toLowerCase();
    data.cookies.all()
      .then(function(resCookies) {
        cookies = resCookies.result;

        return templates.get('cookies');
      })
      .then(function(template) {


        var groups = _.chain(cookies)
          .groupBy('category')
          .map(function(cookies, categoryName) {
            return {
              category: categoryName,
              cookies: cookies
            }
          })
          .filter(function(group) {
            if (category) {
              return group.category.toLowerCase() === category;
            }
            else {
              return group;
            }
          })
          .value();

        var user = {
          username: localStorage.getItem('STORAGE_USERNAME') || ''
        };
        context.$element().html(template({groups: groups, currentUser: user}))

        $('#cookies-container').on('click', 'a', function(ev) {
          var $target = $(ev.target);


          if ($target.attr('id') === 'share-cookie-btn') {
            var cookie = {
              'text': $target.parents('.btn-container-cookie').siblings('.cookie-text').text(),
              'category': $target.parents('.categories-container').find('.cookie-category').text(),
              'img': $target.parents('.btn-container-cookie').siblings('img').attr('src')
            };
            data.cookies.share(cookie).then(function() {
              context.redirect('#/')
            });
          }

          else if ($target.attr('id') === 'like-cookie-btn') {

            var id = $target.parents('.single-cookie-container').attr('data-id');
            console.log(id);
            data.cookies.update(id, 'like').then(function() {
              toastr.success('Cookie liked')
            });
          }

          else if ($target.attr('id') === 'dislike-cookie-btn') {

            var id = $target.parents('.single-cookie-container').attr('data-id');
            console.log(id);
            data.cookies.update(id, 'dislike').then(function() {
              toastr.success('Cookie disliked')
            });

          }



        })

        utilities.processUserButtons();


      })


  }

  function shareNew(context) {
    templates.get('cookie-share-new')
      .then(function(template) {
        var user = {
          username: localStorage.getItem('STORAGE_USERNAME')
        }
        context.$element().html(template(user));
        utilities.processUserButtons();
        $('#cookie-add-btn').on('click', function() {

          if ($('#tb-cookie-image').val()) {
            if (validator.validateUrl($('#tb-cookie-image').val())
              && validator.validateLength($('#tb-cookie-text').val())
              && validator.validateLength($('#tb-cookie-category').val())) {
              var cookie = {
                'text': $('#tb-cookie-text').val(),
                'category': $('#tb-cookie-category').val().toLowerCase(),
                'img': $('#tb-cookie-image').val()
              };
            } else {
              toastr.error("Invalid cookie data")
              return;
            }
          } else {
            if (validator.validateLength($('#tb-cookie-text').val())
              && validator.validateLength($('#tb-cookie-category').val())) {
              var cookie = {
                'text': $('#tb-cookie-text').val(),
                'category': $('#tb-cookie-category').val().toLowerCase(),
                'img': 'http://vignette1.wikia.nocookie.net/lego/images/d/d1/Batman.png/revision/20141219224908'
              };
            } else {
              toastr.error("Invalid cookie data")
              return;
            }
          }
          data.cookies.share(cookie)
            .then(function(cookie) {
              toastr.success(cookie.result.text + ' added')
              context.redirect('#/home');
            })
            .catch(function(err) {
              toastr.error(err.responseJSON)
            })
        })

        return data.categories.get();
      }).then(function(categories) {
        $('#tb-cookie-category').autocomplete({
          source: categories.result,
          minLength: 0
        }).focus(function() {
          $(this).autocomplete('search', $(this).val())
        });
      })
  }


  function myCookie(context){

    var myCookie;
    data.cookies.myCookie()
      .then(function(resCookie) {
        myCookie = resCookie.result;

        return templates.get('my-cookie');
      })
      .then(function(template) {

        var user = {
          username: localStorage.getItem('STORAGE_USERNAME') || ''
        };

        $('#cookies-container').on('click', 'a', function(ev) {
          var $target = $(ev.target);


          if ($target.attr('id') === 'share-cookie-btn') {
            var cookie = {
              'text': $target.parents('.btn-container-cookie').siblings('.cookie-text').text(),
              'category': $target.parents('.categories-container').find('.cookie-category').text(),
              'img': $target.parents('.btn-container-cookie').siblings('img').attr('src')
            };
            data.cookies.share(cookie).then(function() {
              context.redirect('#/')
            });
          }

          else if ($target.attr('id') === 'like-cookie-btn') {

            var id = $target.parents('.single-cookie-container').attr('data-id');
            console.log(id);
            data.cookies.update(id, 'like').then(function() {
              toastr.success('Cookie liked')
            });
          }

          else if ($target.attr('id') === 'dislike-cookie-btn') {

            var id = $target.parents('.single-cookie-container').attr('data-id');
            console.log(id);
            data.cookies.update(id, 'dislike').then(function() {
              toastr.success('Cookie disliked')
            });

          }
        })

        console.log(myCookie);
        context.$element().html(template({myCookie: myCookie, currentUser: user}))

        utilities.processUserButtons();
        })


  }


  //function sortCookies(context){
  //
  //  var cookies;
  //  var sortBy = this.params.likes || '';
  //  sortBy = sortBy.toLowerCase();
  //  data.cookies.all()
  //    .then(function(resCookies) {
  //      cookies = resCookies.result;
  //
  //
  //
  //      return templates.get('cookies');
  //    })
  //    .then(function(template) {
  //
  //
  //      _.cookies.sortBy(option);
  //
  //      var user = {
  //        username: localStorage.getItem('STORAGE_USERNAME') || ''
  //      };
  //      context.$element().html(template({cookies: cookies, currentUser: user}))
  //
  //      })
  //
  //      utilities.processUserButtons();
  //
  //
  //
  //
  //
  //}

  return {
    all: all,
    shareNew: shareNew,
    myCookie: myCookie
    //sortCookies: sortCookies
  }
}();