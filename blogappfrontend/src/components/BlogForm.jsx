import React, { useState } from 'react';
import axios from 'axios';

function BlogForm({ token }) {
    const [title, setTitle] = useState('');
    const [content, setContent] = useState('');
    const [message, setMessage] = useState('');
    

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const res = await axios.post(
                'https://localhost:7026/api/blogApi',
                { title, content,
                "createdAt": "2025-06-04T13:33:18.093Z",
                "author": "binod"
            } ,
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                        'Content-Type': 'application/json'
                    }
                }
            );
            console.log(res);
            setMessage('Blog posted successfully!');
        } catch (err) {
            setMessage('Error posting blog.');
            console.error(err);
        }
    };

    return (
        <div style={{ maxWidth: '600px', margin: 'auto' }}>
            <h2>Create a Blog Post</h2>

            

            <form onSubmit={handleSubmit}>
                <div>
                    <label>Title:</label><br />
                    <input
                        type="text"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        required
                        style={{ width: '100%' }}
                    />
                </div>

                <div>
                    <label>Content:</label><br />
                    <textarea
                        value={content}
                        onChange={(e) => setContent(e.target.value)}
                        required
                        rows="6"
                        style={{ width: '100%' }}
                    />
                </div>

                <button type="submit">Submit Blog</button>
            </form>

            {message && <p>{message}</p>}
        </div>
    );
}

export default BlogForm;
