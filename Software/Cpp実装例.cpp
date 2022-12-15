#include <iostream>
#include <mmdeviceapi.h>
#include <endpointvolume.h>
#include <system_error>

bool isMicrophoneRecording()
{
    IMMDeviceEnumerator* pEnumerator = NULL;
    IMMDevice* pDevice = NULL;

    HRESULT hr = CoInitialize(NULL);
    if (!SUCCEEDED(hr))
    {
        std::cout << std::system_category().message(hr) << std::endl;
    }

    hr = ::CoCreateInstance(__uuidof(MMDeviceEnumerator), NULL,
        CLSCTX_ALL, __uuidof(IMMDeviceEnumerator),
        (void**)&pEnumerator);
    if (!SUCCEEDED(hr))
    {
        std::cout << std::system_category().message(hr) << std::endl;
        if (pEnumerator != NULL) pEnumerator->Release();
        return false;
    }

    IMMDeviceCollection* pDevices;
    hr = pEnumerator->EnumAudioEndpoints(eCapture, DEVICE_STATE_ACTIVE, &pDevices);
    if (!SUCCEEDED(hr) || !pDevices)
    {
        return false;
    }
    bool result = false;
    UINT count;
    pDevices->GetCount(&count);
    for (UINT i = 0; i < count; i++)
    {
        pDevices->Item(i, &pDevice);
        IAudioMeterInformation* pMeterInfo = NULL;
        hr = pDevice->Activate(__uuidof(IAudioMeterInformation), CLSCTX_ALL, NULL, (void**)&pMeterInfo);
        if (!SUCCEEDED(hr))
        {
            std::cout << std::system_category().message(hr) << std::endl;
            if (pMeterInfo != NULL) pMeterInfo->Release();
            if (pDevice != NULL) pDevice->Release();
            if (pEnumerator != NULL) pEnumerator->Release();
            return false;
        }
        float peakValue;
        hr = pMeterInfo->GetPeakValue(&peakValue);
        result |= SUCCEEDED(hr) && peakValue > 0.0f;
        pMeterInfo->Release();
    }

    if (pDevice != NULL) pDevice->Release();
    if (pEnumerator != NULL) pEnumerator->Release();

    return result;
}

int main()
{
    while (true)
    {
        if (isMicrophoneRecording()) {
            std::cout << "マイク使用中" << std::endl;
        }
        else {
            std::cout << "マイクは使われていません" << std::endl;
        }
        Sleep(1000);
    }

    return 0;
}
