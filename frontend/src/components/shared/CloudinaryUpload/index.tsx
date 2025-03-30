import { useState } from 'react'
import { Upload } from '@/components/ui'
import type { UploadProps } from '@/components/ui/Upload'

interface CloudinaryUploadProps {
    onUploadComplete: (url: string) => void
    onUploadError?: (error: string) => void
    value?: string
    childForm?: boolean
}

const CloudinaryUpload = ({ onUploadComplete, onUploadError, value }: CloudinaryUploadProps) => {
    const [uploading, setUploading] = useState(false)

    const handleUpload: UploadProps['onChange'] = async (files) => {
        try {
            setUploading(true)
            const file = files[0]
            
            const formData = new FormData()
            formData.append('file', file)
            formData.append('upload_preset', 'YOUR_CLOUDINARY_UPLOAD_PRESET')

            const response = await fetch(
                'https://api.cloudinary.com/v1_1/YOUR_CLOUD_NAME/auto/upload',
                {
                    method: 'POST',
                    body: formData,
                }
            )

            const data = await response.json()

            if (data.secure_url) {
                onUploadComplete(data.secure_url)
            } else {
                onUploadError?.('Upload failed')
            }
        } catch (error) {
            onUploadError?.('Upload failed')
        } finally {
            setUploading(false)
        }
    }

    return (
        <Upload
            onChange={handleUpload}
            showList={false}
            multiple={false}
            draggable
            disabled={uploading}
            // accept={['image/*', 'video/*']}
        >
            <div className="flex flex-col items-center justify-center">
                {value ? (
                    <img 
                        src={value} 
                        alt="Preview" 
                        className="w-32 h-32 object-cover rounded-lg mb-2"
                    />
                ) : (
                    <div className="text-center">
                        <p className="font-semibold">
                            {uploading ? 'Uploading...' : 'Click or drag file to upload'}
                        </p>
                        <p className="text-sm text-gray-500 mt-1">
                            Support for images and videos
                        </p>
                    </div>
                )}
            </div>
        </Upload>
    )
}

export default CloudinaryUpload