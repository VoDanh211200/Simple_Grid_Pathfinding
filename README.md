# Dự án Simple_Grid_Pathfinding

## Giới thiệu
Đây là một demo đơn giản được xây dựng bằng Unity, cho phép sinh ngẫu nhiên bản đồ lưới (grid) với các chướng ngại vật, sau đó sử dụng thuật toán A* để tìm đường từ điểm bắt đầu đến điểm đích và hiển thị trực quan đường đi trên bản đồ.

### Mục tiêu
- Minh họa cách xây dựng hệ thống sinh map ngẫu nhiên trong Unity.
- Trình bày cách triển khai và trực quan hóa thuật toán A* (A Star) để tìm đường.
- Cho phép người dùng tùy chỉnh kích thước, tỷ lệ chướng ngại và vị trí bắt đầu/đích.

## Tính năng chính
- **Sinh bản đồ** ngẫu nhiên với tham số:
  - Kích thước lưới (chiều rộng, chiều cao).
  - Xác suất xuất hiện chướng ngại vật.
- **Chọn ngẫu nhiên** điểm bắt đầu và điểm đích duy nhất.
- **Thuật toán A*** tìm đường ngắn nhất dựa trên heuristic Manhattan.
- **Tô màu** các ô:
  - Màu xám cho chướng ngại.
  - Màu xanh lá cho điểm bắt đầu.
  - Màu đỏ cho điểm đích.
  - Màu xanh nước biển cho đường đi.
- **Giao diện UI** đơn giản với nút `Generate` để sinh và tìm đường mới.


## Hướng dẫn chạy

1. **Chạy thử**
   - Nhấn nút Play trong Unity Editor.
   - Giao diện hiện nút `Generate Map`. Nhấn để sinh map mới và tìm đường.
   - Xem full map ở màn hình Sence. 

