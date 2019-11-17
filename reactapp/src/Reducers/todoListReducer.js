/**
 * Todo list reducer with some initial objects
 */
const todoListReducer = (state = [
        {title: "Update storage", status: true},
        {title: "Add the pair of Chair 66's that arrived yesterday", status: true},
        {title: "Add more tables", status: false}
    ], 
    action) => {
        switch(action.type) {
            case "ADD_TODO":
                const todoList = state.map( todo => todo );
                todoList.push(action.newTodo);
                return todoList;
            default:
                return state;
        }
}

export default todoListReducer;