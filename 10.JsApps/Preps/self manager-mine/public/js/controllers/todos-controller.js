var todosController = function() {

  function all(context) {

    var todos;
    var category = this.params.category || '';
    category = category.toLowerCase();
    data.todos.get()
      .then(function(resTodos) {
        todos = resTodos.result;

        return templates.get('todos');
      })
      .then(function(template) {


        var groups = _.chain(todos)
          .groupBy('category')
          .map(function(todos, categoryName) {
            return {
              category: categoryName,
              todos: todos
            }
          })
          .filter(function(group) {
            if (category) {
              return group.category === category;
            }
            else {
              return group;
            }
          })
          .value();

        var user = {
          username: localStorage.getItem('STORAGE_USERNAME')
        };
        context.$element().html(template({groups: groups, user: user}))

        utilities.processUserButtons();
        $('.todo-state').on('change', function() {
          var id = $(this).parents('.todo-item').attr('data-id');
          var state = !!$(this).prop('checked');

          data.todos.updateState(id, state)
            .then(function() {

            });
        })


      })


  }

  function add(context) {
    templates.get('todo-add')
      .then(function(template) {
        var user = {
          username: localStorage.getItem('STORAGE_USERNAME')
        }
        context.$element().html(template(user))
        utilities.processUserButtons();
        $('#todo-add-btn').on('click', function() {
          var todo = {
            'text': $('#tb-todo-text').val(),
            'category': $('#tb-todo-category').val().toLowerCase()
          }
          data.todos.add(todo)
            .then(function(todo) {
              toastr.success(todo.result.text + ' added')
              context.redirect('#/todos')
            })
            .catch(function(err) {
              toastr.error(err.responseJSON)
            })
        })

        return data.categories.get();
      }).then(function(categories) {
        $('#tb-todo-category').autocomplete({
          source: categories.result,
          minLength: 0
        }).focus(function() {
          $(this).autocomplete('search', $(this).val())
        });
      })
  }


  return {
    all: all,
    add: add
  }
}();