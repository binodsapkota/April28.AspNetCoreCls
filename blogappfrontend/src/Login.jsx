import React, { useState } from 'react';
import { login } from './api';
import BlogList from './BlogList';

export default function Login() {
    const [form, setForm] = useState({ username: '', password: '' });
    const [token, setToken] = useState(null);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const res = await login(form);
            setToken(res.data.token);
        } catch (err) {
            alert('Login failed: '+err);
        }
    };

    if (token) return <BlogList token={token} />;

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="Username"
                value={form.username}
                onChange={(e) => setForm({ ...form, username: e.target.value })}
            />
            <input
                type="password"
                placeholder="Password"
                value={form.password}
                onChange={(e) => setForm({ ...form, password: e.target.value })}
            />
            <button type="submit">Login</button>
        </form>
    );
}
