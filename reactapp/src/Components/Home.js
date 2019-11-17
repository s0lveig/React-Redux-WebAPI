import React from 'react';
import { useSelector } from 'react-redux';
import AddTask from './AddTask';
import Button from 'react-bootstrap/Button';

/**
 * The Home component with main links to product categories,
 * also holding the task board and it's functionality.
 */
const Home = () => {
    const todoList = useSelector( state => state.todoList );

    const getTodos = () => {
        let todos = todoList.map( todo => {
            if(todo.status === false){
            return <div className="col-12 col-md-6 mb-2">
                    <div className="card bg-warning">
                        <div className="card-body">
                            <p className="card-title">{todo.title}</p>
                        </div>
                    </div>
                </div>
            }
        });
        return todos;
    }

    const getDoneTasks = () => {
        let todos = todoList.map( todo => {
            if(todo.status === true){
            return <div className="col-12 col-md-6 mb-2">
                    <div className="card bg-info">
                        <div className="card-body">
                            <p className="card-title">{todo.title}</p>
                        </div>
                    </div>
                </div>
            }
        });
        return todos;
    }

    return(
        <section className="container-fluid">
            <div id="home-container">
                <h2 className="text-center mt-5 mb-5">Welcome to your admin panel</h2>
                <div className="text-center mb-5">
                    <p>Go to a product category page to edit your shop content</p>
                    
                    <Button size="lg" className="p-4 m-2" variant="secondary" href="/chairs">Chairs</Button>
                    <Button size="lg" className="p-4 m-2" variant="secondary" href="/tables">Tables</Button>
                </div>
            </div>

            <div className="bg-white rounded border mt-5" id="taskboard">
                <h3 className="text-center text-uppercase mt-5 mb-5">Task Board</h3>
                <AddTask />
                <div className="row mt-3 mr-3 ml-3 mb-5">
                    <div className="col-12 col-sm-6 mt-4">
                        <h5 className="text-uppercase">Todo</h5>
                        <div className="row">{ getTodos() }</div>
                    </div>
                    <div className="col-12 col-sm-6 mt-4">
                        <h5 className="text-uppercase">Done</h5>
                        <div className="row">{ getDoneTasks() }</div>
                    </div>
                </div>
            </div>
        </section>
    )
}

export default Home;