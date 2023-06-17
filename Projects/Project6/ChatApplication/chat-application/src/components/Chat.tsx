import React, { useState, useEffect, useRef } from 'react';
import 'semantic-ui-css/semantic.min.css';
import { Button, Form, Input } from 'semantic-ui-react';
import * as signalR from '@microsoft/signalr';

const Chat: React.FC = () => {
    const [username, setUsername] = useState('');
    const [isChatting, setIsChatting] = useState(false);
    const [hubConnection, setHubConnection] = useState<signalR.HubConnection | null>(null);
    const [message, setMessage] = useState('');
    const [chatMessages, setChatMessages] = useState<string[]>([]);
    const chatContainerRef = useRef<HTMLDivElement>(null);

    const handleUsernameSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setIsChatting(true);
        await hubConnection?.invoke('UserConnected', username);
    };

    const handleLeaveChat = async () => {
        setIsChatting(false);
        setUsername('');
        await hubConnection?.invoke('UserDisconnected', username);
    };

    const handleSendMessage = async () => {
        if (message.trim() === '') return;
        await hubConnection?.invoke('SendMessage', username, message);
        setMessage('');
    };

    const isJoinButtonDisabled = username.trim() === '';

    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl('https://localhost:7047/Hubs/ChatHub')
            .build();

        const startSignalRConnection = async () => {
            try {
                await connection.start();
                console.log('Connected to SignalR hub');
            } catch (error) {
                console.log('Error connecting to SignalR hub:', error);
            }
        };

        connection.on('ReceiveMessage', (user: string, msg: string) => {
            setChatMessages((prevMessages) => [...prevMessages, `${user}: ${msg}`]);
        });

        startSignalRConnection();
        setHubConnection(connection);

        return () => {
            connection.stop();
        };
    }, []);

    useEffect(() => {
        if (chatContainerRef.current) {
            chatContainerRef.current.scrollTop = chatContainerRef.current.scrollHeight;
        }
    }, [chatMessages]);

    return (
        <div>
            {!isChatting ? (
                <Form onSubmit={handleUsernameSubmit}>
                    <Form.Field>
                        <Input
                            type="text"
                            placeholder="Username"
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                        />
                    </Form.Field>
                    <Button primary type="submit" disabled={isJoinButtonDisabled}>
                        Join Chat
                    </Button>
                </Form>
            ) : (
                <div>
                    <h2>Welcome to the chat, {username}!</h2>
                    <div ref={chatContainerRef} style={{ maxHeight: '400px', overflowY: 'auto' }}>
                        {chatMessages.map((message, index) => (
                            <p key={index}>{message}</p>
                        ))}
                    </div>
                    <div style={{ marginTop: '1rem' }}>
                        <Input
                            type="text"
                            placeholder="Type your message..."
                            value={message}
                            onChange={(e) => setMessage(e.target.value)}
                        />
                        <Button onClick={handleSendMessage} primary>
                            Send
                        </Button>
                    </div>
                    <Button onClick={handleLeaveChat} color="red" primary>
                        Leave Chat
                    </Button>
                </div>
            )}
        </div>
    );
};

export default Chat;
