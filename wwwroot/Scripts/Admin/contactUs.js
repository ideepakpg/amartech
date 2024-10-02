async function submitContactUs() {
    debugger
    const requestData = {
        Name: document.getElementById('name').value,
        Email: document.getElementById('email').value,
        Subject: document.getElementById('subject').value,
        Message: document.getElementById('message').value,
    };

    const { Name, Email, Subject, Message } = requestData;
    if (!Name || !Email || !Subject || !Message) {
        alert('Please fill in all fields before submitting');
        return;
    }

    if (!/^[a-zA-Z\s]+$/.test(Name)) {
        alert('Please enter a valid name');
        return;
    }

    if (!/^\S+@\S+\.\S+$/.test(Email)) {
        alert('Please enter a valid email address');
        return;
    }

    try {
        const response = await fetch('/Contact/SubmitContactUs', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(requestData),
        });

        if (response.ok) {
            alert('Your message has been sent successfully!');
            document.getElementById('name').value = '';
            document.getElementById('email').value = '';
            document.getElementById('subject').value = '';
            document.getElementById('message').value = '';
        } else {
            alert('An error occurred while sending your message.');
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An unexpected error occurred.');
    }
}
