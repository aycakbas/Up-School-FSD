import React, {useEffect, useRef, useState} from 'react';
import {Button, Input, List, Segment} from 'semantic-ui-react';
import './App.css';
import 'semantic-ui-css/semantic.min.css';

interface Todo {
    id: number;
    task: string;
    isCompleted: boolean;
    createdDate: Date;
}

const App: React.FC = () => {
    const [todos, setTodos] = useState<Todo[]>([]);
    const [newTodo, setNewTodo] = useState<string>('');

    const todosEndRef = useRef<HTMLDivElement>(null);

    useEffect(() => {
        if (todosEndRef.current) {
            todosEndRef.current.scrollIntoView({ behavior: 'smooth' });
        }
    }, [todos]);

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setNewTodo(e.target.value);
    };

    const handleAddTodo = () => {
        if (newTodo.trim() === '') return;
        const newTask: Todo = {
            id: Date.now(),
            task: newTodo.trim(),
            isCompleted: false,
            createdDate: new Date(),
        };
        setTodos([...todos, newTask]);
        setNewTodo('');
    };

    const handleToggleCompletion = (id: number) => {
        const updatedTodos = todos.map((todo) => {
            if (todo.id === id) {
                return {...todo, isCompleted: !todo.isCompleted};
            }
            return todo;
        });
        setTodos(updatedTodos);
    };

    const handleDeleteTodo = (id: number) => {
        const filteredTodos = todos.filter((todo) => todo.id !== id);
        setTodos(filteredTodos);
    };

    const handleSortByDateAsc = () => {
        const sortedTodos = [...todos].sort(
            (a, b) => a.createdDate.getTime() - b.createdDate.getTime()
        );
        setTodos(sortedTodos);
    };

    const handleSortByDateDesc = () => {
        const sortedTodos = [...todos].sort(
            (a, b) => b.createdDate.getTime() - a.createdDate.getTime()
        );
        setTodos(sortedTodos);
    };

    return (
        <div className="App">
            <Segment className="TodoApp">
                <h2>ToDos</h2>
                <Input
                    placeholder="New Todo"
                    value={newTodo}
                    onChange={handleInputChange}
                    action={
                        <Button
                            disabled={newTodo.trim() === ''}
                            onClick={handleAddTodo}
                            color="black"
                        >
                            Add
                        </Button>
                    }
                    fluid
                />
                <div className="SortButtons">
                    <Button onClick={handleSortByDateAsc} color="black">Sort Ascending</Button>
                    <Button onClick={handleSortByDateDesc} color="black">Sort Descending </Button>
                </div>
                <div className="TodoList">
                    <List divided relaxed>
                        {todos.map((todo) => (
                            <List.Item
                                key={todo.id}
                                style={{textDecoration: todo.isCompleted ? 'line-through' : 'none'}}
                                onDoubleClick={() => handleToggleCompletion(todo.id)}
                            >
                                <List.Content
                                    floated="right"
                                    style={{display: 'flex', alignItems: 'center'}}>
                                    <Button
                                        icon="trash"
                                        onClick={() => handleDeleteTodo(todo.id)}
                                        color="red"
                                    />
                                </List.Content>
                                <List.Content>{todo.task}</List.Content>
                                <List.Content floated="right">
                                    {todo.createdDate.toLocaleString()}
                                </List.Content>
                            </List.Item>
                        ))}
                    </List>
                    <div ref={todosEndRef} />
                </div>
            </Segment>
        </div>
    );
};

export default App;