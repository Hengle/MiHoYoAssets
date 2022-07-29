﻿namespace MiHoYoAssets.Formats
{
    public class BH3 : Format
    {
        private const string Signature = "UnityFS";

        private static readonly byte[] ExpansionKey = new byte[] { 0x87, 0xA5, 0x7F, 0xFA, 0x75, 0x53, 0x8B, 0x29, 0xA9, 0x72, 0x62, 0x68, 0xAD, 0x4D, 0x83, 0x81, 0x0A, 0xB1, 0x2E, 0xAA, 0x63, 0x88, 0xF2, 0x18, 0x6C, 0xB2, 0xBC, 0xDC, 0x4A, 0x95, 0x30, 0x07, 0x81, 0x1D, 0xEF, 0x5E, 0x16, 0xC3, 0x9B, 0x86, 0x77, 0x8F, 0xEC, 0x0E, 0x2A, 0x22, 0xF1, 0x6B, 0x52, 0x79, 0xD6, 0xEB, 0xF0, 0xC8, 0xD8, 0x0C, 0x72, 0x92, 0xDD, 0x57, 0xE1, 0xF8, 0x42, 0x2B, 0x5E, 0x44, 0x44, 0x48, 0x9A, 0xC6, 0x21, 0x6E, 0xED, 0x44, 0xE8, 0x35, 0x11, 0x5C, 0x93, 0x73, 0xA5, 0x9C, 0xA1, 0x67, 0x29, 0x51, 0x62, 0xEE, 0xE7, 0x15, 0x85, 0xBE, 0xAD, 0x20, 0x28, 0xAB, 0x17, 0xEE, 0xE4, 0x90, 0x3A, 0x7A, 0xCE, 0x28, 0xAC, 0xBF, 0xAB, 0xD0, 0xAB, 0xA2, 0xCE, 0x22, 0x47, 0x97, 0x8B, 0xA2, 0xE9, 0x47, 0x0C, 0x38, 0x3C, 0xBB, 0xBA, 0x51, 0xBE, 0x4F, 0xAD, 0xDE, 0x3A, 0xC5, 0x02, 0xDD, 0xB3, 0x50, 0x8B, 0xBA, 0xC6, 0x3E, 0xC2, 0xFD, 0xA7, 0xB8, 0x90, 0xC1, 0x82, 0x6F, 0x82, 0xBF, 0xCC, 0x4D, 0xA3, 0xF0, 0xCB, 0xAC, 0x49, 0x42, 0x8B, 0xFC, 0xFC, 0x8B, 0xDD, 0x3D, 0xA4, 0x11, 0x2F, 0x18, 0x17, 0xB2, 0x62, 0x2B, 0x5A, 0xB6, 0x64, 0xF7, 0xB3, 0xC9 };
        private static readonly byte[] Key = new byte[] { 0x8B, 0xD8, 0xD8, 0x92, 0xB6, 0x54, 0xB5, 0xCC, 0xBA, 0x8B, 0x35, 0x0F, 0x3C, 0x86, 0x97, 0x2B, 0x6C, 0x29, 0x21, 0x23, 0xB1, 0x32, 0x86, 0x00, 0x9C, 0x59, 0xED, 0x30, 0x49, 0xEA, 0xA4, 0x34, 0x8B, 0x65, 0x79, 0x98, 0xBB, 0x91, 0xD4, 0x90, 0xA8, 0xBB, 0x14, 0xB3, 0x4B, 0xF2, 0x24, 0x0B, 0x86, 0xF5, 0x1B, 0x42, 0xBB, 0x32, 0x44, 0xD5, 0xA8, 0xD2, 0x0F, 0x33, 0x16, 0xF3, 0x80, 0x7A, 0x46, 0x1B, 0xC7, 0x8F, 0x06, 0xD2, 0xE3, 0xC0, 0x36, 0x1B, 0x6E, 0x30, 0x10, 0x98, 0xC8, 0x21, 0x08, 0x56, 0x75, 0x76, 0x9D, 0xA1, 0xE7, 0xF8, 0xF4, 0x5F, 0x6E, 0xB3, 0x71, 0xE4, 0xB9, 0x43, 0x44, 0xC1, 0x7A, 0x00, 0xF8, 0x77, 0x20, 0x2B, 0x06, 0x6B, 0xED, 0x3F, 0xE9, 0x74, 0x13, 0x6E, 0xA5, 0x61, 0x2B, 0x1E, 0x45, 0x9C, 0x74, 0xB9, 0x82, 0x22, 0x9F, 0x32, 0xBC, 0xEF, 0x9B, 0x88, 0x5A, 0x9E, 0x55, 0xCC, 0xE5, 0xB5, 0xA2, 0x6A, 0x01, 0xEF, 0xEC, 0x13, 0xCF, 0x3E, 0x4F, 0x7C, 0xA0, 0xF8, 0x91, 0xE6, 0x70, 0x6D, 0x4B, 0xDD, 0xEC, 0x24, 0x14, 0x7B, 0x97, 0x23, 0x00, 0x93, 0x0F, 0xCE, 0xB6, 0x38, 0xB5, 0xB6, 0xB0, 0x95, 0x4E, 0x0E, 0x07, 0xE0, 0xEE, 0x6D, 0x0E, 0xDC, 0xB2, 0x3D, 0xC9, 0x7A, 0xA5, 0x41, 0xB2, 0x02, 0xAD, 0xDE, 0x72, 0x10, 0x65, 0xCC, 0x7A, 0x7E, 0xCC, 0xD0, 0x69, 0xC6, 0xA7, 0xB2, 0xB6, 0x38, 0x76, 0x55, 0x6B, 0xA0, 0xAD, 0xF1, 0xEF, 0xA0, 0x9D, 0xCF, 0x2E, 0x89, 0x07, 0x64, 0x6F, 0x1D, 0xE0, 0x51, 0x43, 0xB3, 0x4C, 0x15, 0x65, 0x71, 0x76, 0xFD, 0x1E, 0x0A, 0xA3, 0x00, 0x18, 0x36, 0x12, 0xB0, 0xFB, 0x31, 0xCE, 0x22, 0x2D, 0xD4, 0xFD, 0x09, 0x1D, 0x1A, 0x99, 0x19, 0xFA, 0x02, 0x48, 0x4D, 0xC8, 0x42, 0xA1, 0x2B, 0x8D, 0xA6, 0xF2, 0x53, 0x19, 0x92, 0x57, 0x67, 0xBD, 0xB2, 0x90, 0xE6, 0x01, 0x36, 0xEE, 0x99, 0x1D, 0xC6, 0x30, 0xA0, 0x41, 0xFE, 0xAC, 0x06, 0xC0, 0x56, 0xEE, 0xF4, 0xB8, 0x31, 0xDF, 0xDE, 0xE6, 0x9E, 0x6E, 0x61, 0x42, 0x59, 0xD6, 0x99, 0x0F, 0x87, 0x1E, 0xDD, 0x9D, 0xB5, 0xCA, 0xBC, 0xF9, 0x82, 0xE2, 0x27, 0xD2, 0x2C, 0x5E, 0x51, 0xD8, 0x11, 0x17, 0x4A, 0x32, 0xA3, 0x6E, 0xCB, 0x33, 0xEE, 0x00, 0xC2, 0x22, 0xF8, 0x2C, 0x7E, 0x52, 0x0B, 0xB8, 0x84, 0x83, 0xD7, 0x65, 0x5A, 0x18, 0x4F, 0xB9, 0x54, 0x26, 0x05, 0x02, 0x4D, 0x52, 0x65, 0xAA, 0x03, 0x30, 0x16, 0x45, 0x43, 0x41, 0xDC, 0xBA, 0x75, 0xBD, 0xF2, 0x23, 0xCB, 0xF5, 0x32, 0xE6, 0x41, 0xEC, 0x06, 0x09, 0x86, 0xC2, 0x2C, 0xC0, 0xD7, 0x09, 0xE7, 0xA2, 0xE3, 0x61, 0xFC, 0x10, 0x03, 0x96, 0xF2, 0x3D, 0x31, 0x97, 0x0F, 0x0B, 0x3C, 0x64, 0x9D, 0xC8, 0x72, 0x1C, 0xF5, 0x6B, 0x9A, 0x13, 0x0D, 0xED, 0x0E, 0xB0, 0xFE, 0x4E, 0x48, 0x51, 0x38, 0x90, 0x01, 0x60, 0x61, 0xF3, 0x10, 0x98, 0xFB, 0xDF, 0x13, 0x76, 0x3A, 0x70, 0x6F, 0x1E, 0x05, 0x13, 0xB1, 0x77, 0x8F, 0xDF, 0x37, 0xA3, 0x96, 0xFD, 0xFA, 0x05, 0xFE, 0x6E, 0xAA, 0xBB, 0x12, 0x12, 0xE6, 0x89, 0xAD, 0xCA, 0x20, 0x0D, 0x4C, 0x35, 0x08, 0xFF, 0xC7, 0x92, 0x68, 0x9D, 0x5B, 0xAC, 0x38, 0xA2, 0x7C, 0x04, 0x2B, 0x2F, 0x02, 0x99, 0x81, 0x17, 0x97, 0xC4, 0x92, 0xF7, 0xD8, 0x6F, 0xCE, 0x91, 0x6F, 0x71, 0x5F, 0x31, 0xB4, 0x2F, 0xCC, 0x14, 0x64, 0xA4, 0x32, 0xC0, 0xE5, 0xF1, 0xA0, 0x34, 0xBD, 0x60, 0x87, 0x9A, 0x12, 0x2B, 0x2C, 0xCC, 0x83, 0xEE, 0x99, 0x4A, 0x3E, 0x5A, 0xB5, 0x94, 0x3F, 0xD1, 0x3C, 0x50, 0xB9, 0xAF, 0x1F, 0xFF, 0x8B, 0xB0, 0xAE, 0xF7, 0xC4, 0x1A, 0xFE, 0x8A, 0x95, 0x25, 0x72, 0xAA, 0x23, 0x88, 0x49, 0x98, 0xB3, 0x1D, 0x28, 0x6C, 0xC6, 0x8B, 0xA9, 0x47, 0x33, 0x65, 0xAE, 0xFA, 0x1F, 0xBF, 0x72, 0x2F, 0x0D, 0xBF, 0x33, 0xB4, 0x4B, 0x33, 0x65, 0x08, 0xD6, 0x17, 0x35, 0x8F, 0x75, 0xC9, 0xDF, 0xF4, 0xB7, 0xC2, 0x1A, 0x8F, 0x4D, 0x06, 0x5F, 0x22, 0x2C, 0x62, 0x2E, 0x80, 0x92, 0x9F, 0xF5, 0xF5, 0x09, 0xFA, 0xEE, 0xDB, 0x52, 0xBD, 0x8E, 0x6B, 0x6B, 0x68, 0xD1, 0xBF, 0xFD, 0x9B, 0x51, 0xF6, 0x2B, 0xEC, 0xE4, 0x8C, 0x1D, 0x36, 0x21, 0xCA, 0x08, 0x50, 0x4D, 0x3A, 0xE1, 0x6B, 0x0F, 0x75, 0xC7, 0xC9, 0xC8, 0x76, 0xA1, 0x7D, 0xCD, 0xCD, 0x91, 0x20, 0x65, 0xE6, 0x5E, 0xD9, 0x1A, 0x1A, 0xBD, 0xA5, 0x5D, 0xB9, 0xEA, 0x9D, 0x09, 0xC3, 0x80, 0x45, 0xAD, 0x29, 0x25, 0x4A, 0xAC, 0x9B, 0xFF, 0xBF, 0x43, 0xFC, 0x95, 0x9F, 0x58, 0x66, 0xDB, 0x30, 0xB6, 0xDD, 0x16, 0x3D, 0x18, 0xC2, 0x6B, 0x3D, 0xDB, 0xC0, 0xDC, 0xFC, 0x13, 0xF8, 0x6A, 0xF3, 0x4B, 0x7D, 0x27, 0x14, 0xE7, 0xE5, 0xE5, 0xC2, 0xDF, 0xE6, 0xB3, 0x54, 0xCD, 0x89, 0x30, 0xE3, 0x91, 0x2F, 0xEE, 0x61, 0x9D, 0x60, 0x06, 0xC6, 0x8F, 0x32, 0x74, 0x99, 0x18, 0x44, 0xF8, 0xFE, 0xD8, 0xED, 0xC5, 0x55, 0x29, 0x2C, 0x94, 0x90, 0x96, 0x3E, 0x3D, 0x3C, 0x56, 0xDB, 0xC1, 0xD5, 0xEC, 0x86, 0xFF, 0x86, 0x71, 0xCE, 0xFE, 0x59, 0xC2, 0x33, 0x89, 0x6D, 0xF3, 0x46, 0x88, 0x53, 0xA6, 0xF7, 0x8A, 0x57, 0xF8, 0x0D, 0x1A, 0xD6, 0x8C, 0xD7, 0x44, 0xAF, 0xC6, 0xFF, 0x1E, 0x98, 0x6B, 0xE3, 0x0A, 0xBA, 0x87, 0xEA, 0x02, 0xA9, 0x97, 0x2D, 0x5E, 0x16, 0x81, 0x99, 0xBA, 0xD7, 0x82, 0x5F, 0xCC, 0x1A, 0xDB, 0x79, 0xAB, 0xAD, 0xB4, 0x1F, 0x48, 0x46, 0xCD, 0x06, 0x95, 0xF1, 0xFB, 0x2F, 0xA4, 0x82, 0x03, 0x2B, 0x07, 0xF0, 0x84, 0xEF, 0x93, 0xE7, 0x27, 0x0D, 0xA6, 0x25, 0x02, 0x5E, 0xC2, 0x07, 0xAE, 0x9C, 0xDA, 0x36, 0x03, 0x48, 0xB3, 0x4A, 0xE3, 0x85, 0x8C, 0x60, 0x9E, 0x7D, 0x8E, 0x1C, 0x04, 0x23, 0xE6, 0xD1, 0xCE, 0x3E, 0x89, 0xEA, 0x75, 0xA6, 0xF0, 0x26, 0x3D, 0xD2, 0x84, 0x30, 0x75, 0x8B, 0xD2, 0xA4, 0x76, 0x79, 0x7A, 0x3A, 0x5A, 0x4B, 0xEC, 0xE7, 0x88, 0xC7, 0xCA, 0x9B, 0x65, 0x79, 0xDF, 0x04, 0x56, 0xD1, 0x42, 0x69, 0x04, 0xAB, 0xA7, 0xC1, 0x21, 0xE4, 0x74, 0xA1, 0x6E, 0x9D, 0x0D, 0x75, 0x68, 0x81, 0x58, 0x58, 0x62, 0x9C, 0x68, 0x99, 0xC2, 0xB2, 0x0E, 0x2A, 0x66, 0xD0, 0x01, 0xB2, 0x26, 0xA3, 0x60, 0x4F, 0xBB, 0x53, 0xE3, 0xDC, 0x63, 0xC0, 0xB2, 0x50, 0xFF, 0x55, 0x39, 0x1D, 0x70, 0x82, 0x22, 0xE1, 0xEB, 0x6C, 0x98, 0x52, 0xC2, 0xE1, 0xC4, 0xB7, 0x76, 0x7C, 0x0D, 0xA4, 0xB4, 0xD7, 0x64, 0x44, 0x9F, 0xE2, 0xA5, 0xCC, 0x24, 0x64, 0x9E, 0x67, 0x9D, 0xAA, 0x1D, 0xE5, 0x9F, 0x4A, 0x47, 0x3F, 0x7F, 0x76, 0x30, 0xA9, 0xEE, 0xC7, 0xFA, 0xAA, 0xAA, 0xB2, 0x33, 0x3E, 0x0E, 0x26, 0x8A, 0xA3, 0xC9, 0x03, 0x41, 0x2A, 0xF2, 0xEA, 0x21, 0xE5, 0xE1, 0x59, 0xCA, 0xDD, 0xF1, 0x74, 0x15, 0xB5, 0xC4, 0xED, 0x96, 0x7E, 0x52, 0xA5, 0xCF, 0x0E, 0x3F, 0xDE, 0x0D, 0x39, 0x19, 0x67, 0x99, 0x04, 0xC1, 0x45, 0x21, 0x20, 0xCA, 0x57, 0x9B, 0x29, 0x0F, 0x79, 0xED, 0xC2, 0xB9, 0xBF, 0x29, 0xA2, 0xCA, 0x30, 0xF9, 0xE6, 0x09, 0xAB, 0x58, 0x11, 0x63, 0x15, 0x18, 0xD3, 0x18, 0xFF, 0xF6, 0xD5, 0x23, 0xCC, 0x91, 0x96, 0x25, 0x40, 0x35, 0xDA, 0x4D, 0xB6, 0x85 };
        private static readonly byte[] ConstKey = new byte[] { 0x28, 0x20, 0x24, 0xC9, 0x95, 0x36, 0x70, 0x22, 0xFF, 0x23, 0x0A, 0x03, 0x3F, 0x5D, 0xD0, 0x88 };
        private static readonly byte[] SBox = new byte[] { 0x75, 0x45, 0xC7, 0x35, 0x7E, 0x7B, 0x46, 0x29, 0xE7, 0x10, 0xC1, 0xEB, 0x52, 0xCA, 0xC2, 0xA0, 0x0D, 0xCC, 0x31, 0xA7, 0xA8, 0x44, 0x07, 0x4C, 0x93, 0x6E, 0xFC, 0x0E, 0xF9, 0xFB, 0xDD, 0xAA, 0x4A, 0x84, 0x18, 0xD9, 0x2C, 0x09, 0x21, 0x13, 0x15, 0xBB, 0x37, 0x8E, 0xE2, 0x77, 0x60, 0x22, 0xE8, 0x06, 0x00, 0xA3, 0x56, 0xB7, 0xE9, 0xF1, 0x1B, 0xCB, 0x40, 0xC9, 0x7C, 0xC5, 0xE6, 0xF5, 0xC3, 0x0A, 0x69, 0x5E, 0x9C, 0x39, 0x11, 0x5F, 0xA2, 0xC0, 0xDB, 0x32, 0x8A, 0x3A, 0x63, 0xD8, 0x3F, 0x1A, 0xCE, 0xC6, 0x6C, 0xB3, 0x08, 0x59, 0x64, 0x14, 0x4D, 0x05, 0xD5, 0x34, 0x19, 0x2B, 0x4E, 0x3B, 0x99, 0x1F, 0xD2, 0x28, 0xAF, 0xEF, 0xE0, 0x95, 0x2D, 0xE3, 0xAB, 0x5D, 0x71, 0x53, 0x3E, 0x04, 0x47, 0x25, 0xD7, 0xF8, 0xAC, 0x8C, 0xB2, 0x9A, 0xA9, 0x9F, 0xF7, 0x88, 0xDA, 0x27, 0x9D, 0x89, 0x43, 0x0B, 0x24, 0xBD, 0x26, 0x38, 0x6A, 0xA5, 0x1C, 0xD0, 0xEE, 0x62, 0x67, 0x23, 0x9B, 0xEA, 0xDE, 0x72, 0x6D, 0x80, 0x1E, 0x3D, 0x0F, 0x2E, 0x54, 0xFF, 0x3C, 0x1D, 0xF0, 0x03, 0x5A, 0x65, 0xBC, 0x30, 0x61, 0x57, 0x6B, 0xBF, 0xA6, 0x58, 0x76, 0x2F, 0x01, 0xA1, 0x20, 0xD3, 0x74, 0x2A, 0x97, 0x8F, 0x87, 0x50, 0xAE, 0xDF, 0x55, 0xF3, 0x7F, 0xB0, 0xD6, 0x41, 0xE4, 0x4B, 0x02, 0x86, 0x16, 0x85, 0x7D, 0xBA, 0x0C, 0xD4, 0xFE, 0x7A, 0xC4, 0x51, 0x8D, 0x78, 0xCD, 0x33, 0xE1, 0x98, 0xAD, 0x79, 0x68, 0xB6, 0x17, 0xFD, 0xC8, 0x82, 0x6F, 0x4F, 0xD1, 0x8B, 0xE5, 0x66, 0xFA, 0x91, 0xB5, 0x42, 0x5C, 0x49, 0xB9, 0x73, 0xF6, 0x5B, 0x36, 0xB8, 0xB4, 0xB1, 0xEC, 0x90, 0x81, 0x92, 0xF2, 0xF4, 0x94, 0x83, 0x96, 0x9E, 0x48, 0xBE, 0xDC, 0xED, 0xCF, 0xA4, 0x70, 0x12, 0xA7, 0xA6, 0xF8, 0xF0, 0xD9, 0x1B, 0x85, 0xF4, 0xA9, 0x36, 0xA2, 0xE6, 0xCB, 0xCF, 0x9C, 0x2E, 0x78, 0xCE, 0x67, 0x07, 0x50, 0xF2, 0x0B, 0x2B, 0xB8, 0xA4, 0x1E, 0x28, 0xD7, 0x17, 0x5F, 0x74, 0xC8, 0xDA, 0x2C, 0x86, 0xAD, 0xBB, 0xD8, 0xFB, 0x6C, 0x1A, 0x8F, 0x0C, 0xE4, 0x97, 0x13, 0x2D, 0xB2, 0x5B, 0x65, 0x49, 0x45, 0x7C, 0x7B, 0x38, 0xDE, 0xAC, 0x58, 0x2F, 0x33, 0xD2, 0x52, 0x14, 0x02, 0x9D, 0xF5, 0x6A, 0x43, 0x87, 0xE0, 0x18, 0x69, 0x5E, 0x68, 0xE9, 0xAE, 0xF9, 0x63, 0xBC, 0xBF, 0xC2, 0x94, 0xB4, 0x30, 0xE8, 0x23, 0x0F, 0x64, 0x26, 0x80, 0xB3, 0x8D, 0xC1, 0xE3, 0x15, 0x34, 0x05, 0xC9, 0x29, 0xE2, 0xA8, 0x55, 0xD0, 0x37, 0xDC, 0xF6, 0xBA, 0x0D, 0x8B, 0x8E, 0x60, 0xEA, 0x84, 0x90, 0x48, 0x79, 0x10, 0x9F, 0x1F, 0x8A, 0xBD, 0xFD, 0x39, 0x04, 0x3F, 0xB9, 0x4C, 0x75, 0x3B, 0x22, 0x46, 0x7F, 0xDB, 0x2A, 0x0E, 0x35, 0x40, 0xED, 0xFC, 0x47, 0xB1, 0x7D, 0xD4, 0x62, 0x9E, 0x5D, 0xC5, 0x51, 0xA1, 0x88, 0x89, 0x11, 0x31, 0xC4, 0xFE, 0x27, 0x99, 0x5A, 0x3A, 0x91, 0x81, 0x95, 0x70, 0x1D, 0x12, 0x98, 0x4F, 0x20, 0x92, 0x56, 0x6D, 0xD5, 0xE5, 0xEC, 0xAA, 0xC0, 0xA3, 0x9A, 0x06, 0x32, 0xEE, 0x3D, 0x53, 0x08, 0xD3, 0x3E, 0xDF, 0xE1, 0xA0, 0xC6, 0xB7, 0x03, 0x6B, 0x59, 0xA5, 0x6F, 0x09, 0xD1, 0x93, 0x54, 0xF3, 0x77, 0xC7, 0xBE, 0x8C, 0xE7, 0x25, 0x76, 0x41, 0x71, 0x72, 0xCC, 0x9B, 0x16, 0x7E, 0x4B, 0x44, 0xAF, 0xF7, 0xCD, 0xAB, 0xB0, 0x7A, 0x57, 0xB5, 0x66, 0xEF, 0xEB, 0xFF, 0xB6, 0x00, 0x4E, 0xCA, 0x61, 0xC3, 0xF1, 0x4D, 0x21, 0x1C, 0xDD, 0x0A, 0xD6, 0x4A, 0x5C, 0x42, 0x83, 0x6E, 0x96, 0x19, 0x01, 0x73, 0x3C, 0xFA, 0x24, 0x82, 0x5D, 0x33, 0x3A, 0x97, 0x9D, 0xCE, 0x65, 0x39, 0xFB, 0xEB, 0x51, 0xC1, 0x59, 0x1C, 0xAF, 0x09, 0x27, 0x57, 0xA0, 0xD4, 0x75, 0xCF, 0xF9, 0x8A, 0x3C, 0xAA, 0x6E, 0x6C, 0xE8, 0xDF, 0x12, 0x2A, 0x1D, 0x02, 0xB4, 0x8C, 0x0C, 0xF7, 0x4A, 0xBD, 0xF4, 0x71, 0x16, 0xC2, 0x13, 0x86, 0x50, 0x2D, 0xA7, 0x28, 0x4B, 0x03, 0x17, 0x00, 0x15, 0x25, 0x7C, 0x19, 0xFE, 0x23, 0xF2, 0x0E, 0xC3, 0x9A, 0x0A, 0x1E, 0xF8, 0x7E, 0x70, 0x0B, 0x9E, 0x2C, 0xF3, 0xC9, 0xE4, 0xAE, 0x2E, 0x89, 0x4E, 0xA8, 0x87, 0xD9, 0x7A, 0x18, 0xDB, 0x04, 0xF0, 0xBB, 0x83, 0x8D, 0xE0, 0x92, 0x5F, 0x2B, 0x3E, 0xC0, 0xD5, 0xB6, 0x38, 0x76, 0xC5, 0x4C, 0x29, 0x36, 0x53, 0x41, 0x4D, 0x1F, 0x11, 0x4F, 0xBC, 0xD0, 0xDC, 0x96, 0x24, 0xEC, 0x9F, 0x47, 0x22, 0x6B, 0xCA, 0x56, 0x42, 0xEF, 0x99, 0x7D, 0x43, 0x63, 0x0F, 0xB8, 0x48, 0xAC, 0x55, 0xE1, 0x5E, 0xED, 0xC6, 0xD3, 0xD6, 0x40, 0x3D, 0xA5, 0x44, 0x30, 0xFC, 0xD2, 0x69, 0x32, 0xF6, 0x64, 0x01, 0x46, 0x34, 0xD1, 0xA9, 0x6D, 0x5A, 0x80, 0x35, 0xBA, 0x9C, 0x79, 0xCB, 0x61, 0x78, 0x08, 0x3F, 0x14, 0x8F, 0x94, 0xE3, 0x2F, 0xC8, 0x77, 0x54, 0x49, 0xA2, 0xFF, 0xE2, 0x6A, 0xB0, 0xD7, 0xDD, 0x5B, 0x68, 0xB2, 0x81, 0xA4, 0x1B, 0x05, 0xAB, 0x88, 0xFD, 0x20, 0xB7, 0x93, 0x7B, 0x37, 0xB1, 0x9B, 0xF5, 0xB9, 0xAD, 0xB5, 0x45, 0x73, 0xC4, 0xBE, 0x67, 0x8E, 0x1A, 0x07, 0xE6, 0x58, 0x3B, 0xEA, 0xA3, 0xC7, 0x85, 0x6F, 0x74, 0x8B, 0x60, 0x7F, 0xCD, 0x62, 0xE7, 0xE5, 0xA1, 0x10, 0xF1, 0xDE, 0x21, 0x72, 0x5C, 0x91, 0x31, 0x95, 0xDA, 0x90, 0x26, 0x52, 0xA6, 0xE9, 0x0D, 0xFA, 0x84, 0x98, 0x82, 0xB3, 0x06, 0xD8, 0xEE, 0x66, 0xCC, 0xBF, 0x35, 0x99, 0xD2, 0xA3, 0xC4, 0x83, 0x50, 0xC5, 0x7C, 0x54, 0xB0, 0x27, 0x68, 0xF7, 0xBD, 0xCA, 0x79, 0x08, 0x94, 0x85, 0x6B, 0xC2, 0xC8, 0xEF, 0x46, 0xF8, 0xC6, 0xA1, 0x29, 0x57, 0xD5, 0x5B, 0x11, 0x6F, 0x0F, 0xB6, 0xF9, 0x87, 0xAC, 0xD3, 0x1E, 0x84, 0xFD, 0x43, 0x09, 0xA2, 0x28, 0x56, 0xA0, 0xAD, 0x81, 0x55, 0x98, 0x97, 0x78, 0xE9, 0xDF, 0x1F, 0x2E, 0xE7, 0x9D, 0x59, 0x01, 0x1C, 0x52, 0x88, 0x62, 0x5D, 0x31, 0x30, 0x6D, 0x38, 0x2C, 0x24, 0x32, 0x26, 0x6E, 0xF1, 0x4C, 0x7D, 0x1D, 0x74, 0x7F, 0xC9, 0xD1, 0xD6, 0xB8, 0x51, 0xF5, 0x8D, 0x9A, 0x8F, 0xB5, 0xB3, 0xB2, 0x47, 0x3C, 0x1A, 0x8A, 0xDD, 0xF3, 0xDA, 0x5A, 0xC0, 0xD4, 0x07, 0x12, 0x53, 0x45, 0x93, 0xAB, 0xCB, 0x67, 0x48, 0x00, 0x8C, 0xE1, 0x40, 0x2F, 0x6C, 0x17, 0x22, 0xBA, 0xF4, 0xE5, 0xD7, 0x3E, 0x7E, 0x5E, 0xF6, 0x37, 0x39, 0x20, 0xA4, 0x4A, 0xCC, 0x0A, 0x03, 0x10, 0x33, 0x36, 0x9F, 0x2A, 0x70, 0x5C, 0x9C, 0xFE, 0x0D, 0x41, 0xDE, 0x49, 0x3D, 0x92, 0x89, 0xDB, 0x05, 0x6A, 0x23, 0xE0, 0x8E, 0x8B, 0xAA, 0x77, 0x69, 0x63, 0x0C, 0x2D, 0xA7, 0x14, 0x3F, 0xEB, 0xF0, 0xCD, 0x3B, 0x4B, 0xAE, 0x2B, 0xFA, 0xFB, 0x86, 0x58, 0x9B, 0x34, 0x7A, 0x95, 0xC3, 0x16, 0x96, 0xE3, 0x1B, 0xB7, 0x02, 0x44, 0x4F, 0xAF, 0xBF, 0xFC, 0xB1, 0x13, 0xEE, 0x72, 0x06, 0xD0, 0x04, 0x0B, 0xA8, 0x80, 0xBC, 0x5F, 0x65, 0xDC, 0xE2, 0x60, 0x7B, 0xBB, 0xBE, 0x4D, 0x61, 0xCE, 0xB4, 0x82, 0x18, 0xD9, 0xC7, 0x76, 0x73, 0x66, 0xC1, 0xA5, 0xFF, 0xCF, 0xEA, 0x75, 0xE8, 0x9E, 0x3A, 0xA9, 0xE6, 0x4E, 0x71, 0x21, 0x15, 0x25, 0xF2, 0xE4, 0xB9, 0xA6, 0x19, 0x42, 0x90, 0x0E, 0xEC, 0xED, 0x91, 0x64, 0xD8 };

        public BH3()
        {
            Name = "BH3";
            DisplayName = "Honkai Impact 3";
            Pattern = ("*.wmv", "");
            Extension = ("", "");
        }

        protected override (string, string)[] CollectPaths(string input, string output, bool isEncrypt)
        {
            if (File.Exists(input))
            {
                return new (string, string)[] { (input, output) };
            }
            var files = Directory.GetFiles(input, isEncrypt ? Pattern.Item2 : Pattern.Item1, SearchOption.AllDirectories);
            var paths = new List<(string, string)>();
            foreach (var file in files)
            {
                var relativePath = Path.GetRelativePath(input, file);
                relativePath = isEncrypt ? Path.ChangeExtension(relativePath, Extension.Item2) : Path.Combine(Path.GetDirectoryName(relativePath), Path.GetFileNameWithoutExtension(relativePath));
                var outPath = Path.Combine(output, relativePath);
                paths.Add((file, outPath));
            }
            return paths.ToArray();
        }

        protected override void Decrypt(string input, string output)
        {
            var reader = new EndianReader(input, 0, EndianType.BigEndian);
            while(reader.Remaining > 0)
            {
                var signature = reader.ReadStringToNull();
                if (signature != Signature)
                {
                    throw new InvalidOperationException($"Expected signature ENCR, got {signature} instead !!");
                }

                var key = reader.ReadInt32();
                var header = new Bundle.Header()
                {
                    Flags = reader.ReadInt32(),
                    Size = reader.ReadInt64(),
                    UncompressedBlocksInfoSize = reader.ReadInt32(),
                    CompressedBlocksInfoSize = reader.ReadInt32()
                };
                DecryptHeader(header, key);
                var bundle = new Bundle(header, true, ExpansionKey, Key, ConstKey, SBox);
                reader.Position += 0x12;
                bundle.Process(ref reader, output);
            }
        }

        protected override void Encrypt(string input, string output)
        {
            throw new NotImplementedException();
        }

        private void DecryptHeader(Bundle.Header header, int key)
        {
            var rand = new XORShift128();
            rand.InitSeed(key);
            header.Flags ^= rand.NextDecryptInt();
            header.Size ^= rand.NextDecryptLong();
            header.UncompressedBlocksInfoSize ^= rand.NextDecryptInt();
            header.CompressedBlocksInfoSize ^= rand.NextDecryptInt();
        }
    }
}
