import React, { useState, useEffect } from 'react';

const baseUrl = 'https://localhost:7073/api';

function App() {
    const [token, setToken] = useState('');
    const [email, setEmail] = useState('admin');
    const [password, setPassword] = useState('admin');
    const [todos, setTodos] = useState([]);
    const [title, setTitle] = useState('');

    const login = async () => {
        const res = await fetch(`${baseUrl}/AuthApi`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ username: email, password })
        });

        const data = await res.json();
        if (res.ok) {
            setToken(data.token);
            localStorage.setItem('token', data.token);
        } else {
            alert('Login failed');
        }
    };

    const loadTodos = async () => {
        const res = await fetch(`${baseUrl}/TodoApi`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        if (res.ok) {
            const data = await res.json();
            setTodos(data);
        } else {
            console.error('Failed to load todos');
        }
    };

    const addTodo = async () => {
        const res = await fetch(`${baseUrl}/TodoApi`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify({ title })
        });

        if (res.ok) {
            setTitle('');
            loadTodos();
        }
    };

    const deleteTodo = async (id) => {
        const res = await fetch(`${baseUrl}/TodoApi/${id}`, {
            method: 'DELETE',
            headers: { 'Authorization': `Bearer ${token}` }
        });

        if (res.ok) {
            loadTodos();
        }
    };

    useEffect(() => {
        const saved = localStorage.getItem('token');
        if (saved) setToken(saved);
    }, []);

    useEffect(() => {
        if (token) loadTodos();
    }, [token]);

    return (
        <div style={{ padding: '2rem' }}>
            {!token ? (
                <div>
                    <h2>Login</h2>
                    <input placeholder="Email" value={email} onChange={e => setEmail(e.target.value)} />
                    <input placeholder="Password" type="password" value={password} onChange={e => setPassword(e.target.value)} />
                    <button onClick={login}>Login</button>
                </div>
            ) : (
                <div>
                    <h2>To-Do List</h2>
                    <input
                        placeholder="New to-do"
                        value={title}
                        onChange={e => setTitle(e.target.value)}
                    />
                    <button onClick={addTodo}>Add</button>

                    <ul>
                        {todos.map(todo => (
                            <li key={todo.id}>
                                {todo.title}
                                <button onClick={() => deleteTodo(todo.id)}>❌</button>
                            </li>
                        ))}
                    </ul>
                </div>
            )}
        </div>
    );
}

export default App;
