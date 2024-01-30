const runButton = document.getElementById('btnRun');
runButton.addEventListener('click', async () => {
    const typeRadio = document.querySelector('input[name="encryptionTypeRadioOptions"]:checked');
    const keyInput = document.getElementById('txtKey');
    const ivInput = document.getElementById('txtIv');
    const textTextarea = document.getElementById('taText');
    
    if (keyInput.value === '') {
        alert('Key를 입력해주세요.');
        keyInput.focus();
        return;
    } else if (ivInput.value === '') {
        alert('IV를 입력해주세요.');
        ivInput.focus();
        return;
    }
    
    const res = await fetch('/api/Encryptions', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            encryptionType: typeRadio.value,
            key: keyInput.value,
            iv: ivInput.value,
            text: textTextarea.value
        })
    });
    
    if (!res.ok) {
        alert('오류가 발생하였습니다.');
        return;
    }
    
    const { result } = await res.json();
    
    const resultTextarea = document.getElementById('taResult');
    
    resultTextarea.value = result;
});

const copyButton = document.getElementById('btnCopy');
copyButton.addEventListener('click', async () => {
    const resultTextarea = document.getElementById('taResult');
    
    if (resultTextarea.value === '') {
        alert('복사할 문자열이 없습니다.');
        return;
    }
    
    await window.navigator.clipboard.writeText(resultTextarea.value);

    alert('복사가 완료되었습니다.');
});