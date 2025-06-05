import React, { useEffect, useState } from 'react';
import { getPosts } from './api';
import BlogForm from './components/BlogForm';

export default function BlogList({ token }) {
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        getPosts(token).then((res) => {
            setPosts(res.data);
        });
    }, [token]);

    return (
        <div>
            <h2>new blog</h2>
            <BlogForm token={token} />
            <h2>Blog Posts</h2>
            {posts.map((post) => (
                <div key={post.id} style={{ border: '1px solid gray', padding: '10px', margin: '10px 0' }}>
                    <h3>{post.title}</h3>
                    <p>{post.content}</p>
                </div>
            ))}
        </div>
    );
}
