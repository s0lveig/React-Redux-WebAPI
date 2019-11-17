import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { addTodo } from '../Actions';
import Furniture from './Furniture';

const Home = () => {
    const todoList = useSelector( state => state.todoList );
    const dispatch = useDispatch();

    const getAllTasks = () => {
        let todos = todoList.map( todo => {
            return <li>{todo.title}</li>
        });
        return todos;
    }

    return(
        <section id="home-container" className="container-fluid">
            <div className="text-center mt-5 mb-5">
                <h2>Welcome to your admin panel</h2>

                <form>
                    <input id="input-task" type="text" value="todo" />
                    <input onClick={ ( ) => dispatch( addTodo() ) } type="button" value="Add task" />
                </form>

                <ul>{ getAllTasks() }</ul>
            </div>
            <Furniture />
        </section>
    )
}

export default Home;